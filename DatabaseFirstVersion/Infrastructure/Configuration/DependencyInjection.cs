using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportGroups.Business.Services.IServices;
using SportGroups.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Infrastructure.Configuration
{
    public static class DependencyInjection // 其餘依賴項目: 媒體
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IMediaService, MediaService>();
            
            return services;
        }
    }

}
