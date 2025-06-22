using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ArticleDTOs;

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

        // (依條件)查詢文章
        [HttpGet]
        public async Task<ActionResult<List<ArticleInfoDto>>> SearchArticles([FromQuery] ArticlesQueryConditions condition)
        {
            var articles = await _articleService.GetArticlesByConditionAsync(condition);
            if(articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        // 讀取文章資訊
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

        // 新增文章
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateArticle([FromForm] NewArticleDto newArticleDto)
        {
            var result = await _articleService.CreateArticleAsync(newArticleDto);
            if(result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(ArticlesController.GetArticle), new { articleId = result }, result);
        }

        // 更新文章
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{articleId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromForm] ArticleUpdateDto articleUpdateDto)
        {
            var result = await _articleService.UpdateArticleAsync(articleId, articleUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        // 刪除文章
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            var result = await _articleService.DeleteArticleAsync(articleId);
            return result ? NoContent() : BadRequest();
        }
    }
}
