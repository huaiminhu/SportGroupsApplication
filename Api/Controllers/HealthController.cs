using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly SportGroupsDbContext _context;
        public HealthController(SportGroupsDbContext context)
        {
            _context = context;
        }

        [HttpGet("health")]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                // 嘗試實際執行 SQL 指令（強制用到連線）
                await _context.Database.ExecuteSqlRawAsync("SELECT 1");
                return Ok("✅ DB 連線成功");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ 連線失敗：{ex.Message}");
            }
        }


    }
}
