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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ArticleInfoDto>>> SearchArticles([FromQuery] ArticlesQueryConditions condition)
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

        [HttpGet("{articleId}")]
        public async Task<ActionResult<ArticleInfoDto?>> GetArticle(int articleId)
        {
            var article = await _articleService.GetArticleByIdAsync(articleId);
            if(article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] NewArticleDto newArticleDto)
        {
            var result = await _articleService.CreateArticleAsync(newArticleDto);
            if(result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(ArticlesController.GetArticle), new { articleId = result }, result);
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPut("{articleId}")]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] ArticleUpdateDto articleUpdateDto)
        {
            var result = await _articleService.UpdateArticleAsync(articleId, articleUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            var result = await _articleService.DeleteArticleAsync(articleId);
            return result ? NoContent() : BadRequest();
        }
    }
}
