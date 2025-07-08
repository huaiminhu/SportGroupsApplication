using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ArticleDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IClubMemberService _memberService;
        public ArticlesController(IArticleService articleService, 
            IClubMemberService memberService)
        {
            _articleService = articleService;
            _memberService = memberService;

        }

        // (依條件)查詢文章
        [HttpGet]
        public async Task<ActionResult<List<ArticleInfoDto>>> SearchArticles([FromQuery] ArticlesQueryConditions condition)
        {
            var articles = await _articleService.SearchArticlesAsync(condition);
            if(articles == null)
            {
                return NotFound("找不到任何文章!");
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
                return NotFound("找不到任何文章!");
            }
            return Ok(article);
        }

        // 新增文章
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateArticle([FromForm] NewArticleDto newArticleDto)
        {
            // 驗證發布文章的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var authResult = await _memberService.GetMemberAsync(userId, newArticleDto.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 發布文章
            var result = await _articleService.CreateArticleAsync(newArticleDto);
            if(result == null)
            {
                return BadRequest("發布失敗!");
            }
            return CreatedAtAction(nameof(ArticlesController.GetArticle), new { articleId = result }, result);
        }

        // 更新文章
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{articleId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromForm] ArticleUpdateDto articleUpdateDto)
        {
            // 驗證更新文章的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var getArticle = await _articleService.GetArticleByIdAsync(articleId);
            if (getArticle == null)
            {
                return BadRequest("文章不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getArticle.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 更新文章
            var result = await _articleService.UpdateArticleAsync(articleId, articleUpdateDto);
            return result ? NoContent() : BadRequest("更新失敗!");
        }

        // 刪除文章
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            // 驗證刪除文章的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var getArticle = await _articleService.GetArticleByIdAsync(articleId);
            if (getArticle == null)
            {
                return BadRequest("文章不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getArticle.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 刪除文章
            var result = await _articleService.DeleteArticleAsync(articleId);
            return result ? NoContent() : BadRequest("刪除失敗!");
        }
    }
}
