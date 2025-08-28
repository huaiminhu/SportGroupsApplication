using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SportGroups.Data.Data
{
    public class SGDbCxtFactory   
    {
        // 設定ContextFactory以進行資料庫遷移, 更新時, 可以
        // 使用SportGroupsDbContext設定如連接字串等
        public class SportGroupsDbContextFactory : IDesignTimeDbContextFactory<SportGroupsDbContext>
        {
            public SportGroupsDbContext CreateDbContext(string[] args)
            {
                // 載入appsetting.json
                var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory()) // 指向 API 專案路徑（Startup Project）
                            .AddJsonFile("appsettings.json")
                            .Build();

                // 讀取連接字串
                var connectionString = config.GetConnectionString("SportGroupsDbContext");

                // 使用Sql Server並設定連接字串
                var optionsBuilder = new DbContextOptionsBuilder<SportGroupsDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                // 回傳DbContext物件
                return new SportGroupsDbContext(optionsBuilder.Options);
            }
        }

    }
}