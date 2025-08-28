using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SportGroups.Api.SwaggerSupport;
using SportGroups.Business.Mapping;
using SportGroups.Business.Services;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Data;
using SportGroups.Data.Repositories;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Infrastructure.Configuration;
using SportGroups.Shared.Configurations;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // 用 enum 名稱顯示
    }); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sport Groups API", Version = "v1" });

    // 加入 JWT Bearer 認證方式
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "輸入 JWT Token：Bearer {your token}"
    });

    // 套用到所有需要驗證的 API 上
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    // 讓 enum 在 Swagger UI 顯示字串名稱
    c.SchemaFilter<EnumSchemaFilter>();
});

// 依賴項注入
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IClubEventRepository, ClubEventRepository>();
builder.Services.AddScoped<IClubEventService, ClubEventService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IClubMemberRepository, ClubMemberRepository>();
builder.Services.AddScoped<IClubMemberService, ClubMemberService>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddInfrastructure(config); // Infrastructure層注入

builder.Services.AddDbContext<SportGroupsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportGroupsDbContext")));

// 使用Auto Mapper
builder.Services.AddAutoMapper(typeof(UserProfile));

// 註冊JWT設定
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>() ?? throw new InvalidOperationException("JwtSettings is missing.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles(); // 允許存取 wwwroot
app.Run();
