using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("articles")]
        public async Task<ActionResult<List<ArticleInfoDto>>> SearchArticles([FromQuery]ArticlesQueryConditions condition)
        {
            var articles = await _articleService.GetArticlesByConditionAsync(condition);
            if(articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        //[HttpGet("articles/search")]
        //public async Task<ActionResult<List<ArticleInfoDto>>> GetAllArticlesByKeywordAsync([FromBody]string keyword)
        //{
        //    var articles = await _articleService.GetAllArticlesByKeywordAsync(keyword);
        //    if(articles == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(articles);
        //}

        [HttpGet("article")]
        public async Task<ActionResult<ArticleInfoDto?>> GetArticle([FromBody]int articleId)
        {
            var article = await _articleService.GetArticleByIdAsync(articleId);
            if(article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateArticle(NewArticleDto newArticleDto, List<IFormFile> medias)
        {
            var result = await _articleService.CreateArticleAsync(newArticleDto, medias);
            return result ? CreatedAtAction(nameof(ArticleController.GetArticle), "Article", new { }, result) : BadRequest();
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var result = await _articleService.UpdateArticleAsync(articleUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteArticle([FromBody]int articleId)
        {
            var result = await _articleService.DeleteArticleAsync(articleId);
            return result ? NoContent() : BadRequest();
        }
    }
}
