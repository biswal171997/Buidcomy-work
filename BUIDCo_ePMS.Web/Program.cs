using BUIDCo_ePMS.Repository.Container;
using ExceptionHandling.Middlewares;
using BUIDCO.Web.DIContainer;
using BUIDCo_ePMS.Web.Models;
using NuGet.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Mysqlx.Session;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using BUIDCo_ePMS.Core;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//manoj biswal for bearer token JWT token.
// Add authentication

// Add services to the container.
builder.Services.AddScoped<UserContextService>();
var jwtSettings = builder.Configuration.GetSection("Jwt");

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/CodeGenLogin"; // Redirect unauthorized users
    options.AccessDeniedPath = "/CodeGenLogin";
    options.ExpireTimeSpan = TimeSpan.FromHours(Convert.ToDouble(jwtSettings["TokenValidityInHours"])); // Keep the user logged in for 1 hour
    options.SlidingExpiration = true; // Extend expiration when active
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();

builder.Services.AddCustomContainer(builder.Configuration);
builder.Services.AddADM_ConsoleContainer(builder.Configuration);
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.Name = ".Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.WithOrigins(allowedOrigins) // Change to actual frontend URL
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // ? Allows cookies
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Register HttpClient with BaseAddress from ApiSettings
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri(apiSettings?.BaseUrl );
});
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();//manoj for bearer token JWT token
app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    await next();
});
//app.MapControllerRoute(
//    name: "default",
// pattern: "{controller=CodeGenLogin}/{action=UserLogin}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Login}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=CodeGenLogin}/{action=UserLogin}/{id?}");
});
if (!app.Environment.IsDevelopment())
{
  //  app.UseMiddleware<ExceptionHandlingMiddleware>();
}
app.Run();
