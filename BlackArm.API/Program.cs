using System.Text;
using BlackArm.API.ActionFilters;
using BlackArm.API.AuthenticationService;
using BlackArm.API.Extensions;
using BlackArm.Application.AuthenticationService;
using BlackArm.Application.Contracts;
using BlackArm.Application.LoggerService;
using BlackArm.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureLoggerService();

builder.Services.AddScoped<ValidateArmwrestlerExistsAttribute>();
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ArmWrestlersDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache(); // Добавляем сервис кэширования в памяти
builder.Services.ConfigureResponseCaching();
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("120SecondsDuration" , new CacheProfile
    {
        Duration = 120
    });
})
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.CreateRoles(logger);
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseRouting();
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();