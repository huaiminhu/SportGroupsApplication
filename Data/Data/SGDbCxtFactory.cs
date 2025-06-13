using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportGroups.Data.Data
{
    public class SGDbCxtFactory
    {
        public class SportGroupsDbContextFactory : IDesignTimeDbContextFactory<SportGroupsDbContext>
        {
            public SportGroupsDbContext CreateDbContext(string[] args)
            {
                //var optionsBuilder = new DbContextOptionsBuilder<SportGroupsDbContext>();
                //optionsBuilder.UseSqlServer("SportGroupsDbContext"); 

                //return new SportGroupsDbContext(optionsBuilder.Options);
                var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory()) // 這會抓到 API 專案的路徑（Startup Project）
                            .AddJsonFile("appsettings.json")
                            .Build();

                var connectionString = config.GetConnectionString("SportGroupsDbContext");

                var optionsBuilder = new DbContextOptionsBuilder<SportGroupsDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new SportGroupsDbContext(optionsBuilder.Options);
            }
        }

    }
}