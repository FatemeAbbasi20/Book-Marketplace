using Esther_Shop.CoreLayer.Services;
using Esther_Shop.CoreLayer.Services.Article;
using Esther_Shop.CoreLayer.Services.ArticleCategory;
using Esther_Shop.CoreLayer.Services.ArticleComment;
using Esther_Shop.CoreLayer.Services.Card;
using Esther_Shop.CoreLayer.Services.Category;
using Esther_Shop.CoreLayer.Services.Comment;
using Esther_Shop.CoreLayer.Services.DiscountCodes;
using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Services.Slider;
using Esther_Shop.CoreLayer.Services.User;
using Esther_Shop.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Services= builder.Services;
Services.AddRazorPages()
    //.AddRazorOptions(options => { options.Conventions.AddAuthorizaAreaFolder("Admin", "/", "AdminPolicy")})
  .AddRazorRuntimeCompilation();
Services.AddAuthorization(option =>option.AddPolicy("AdminPolicy", builder => builder.RequireRole("Admin")));
Services.AddDbContext<BlogContext>(option=>
 { option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
   
});
Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(option =>
{
    option.LoginPath = "/Login";
    //option.LogoutPath = "/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
});

Services.AddTransient<IUserService,UserService>();
Services.AddScoped<ICategoryService, CategoryService>();
Services.AddScoped<IFileManager, FileManager>();
Services.AddScoped<ISliderService, SliderService>();
Services.AddScoped<IProductCommentService,ProductCommentService>();
Services.AddScoped<IMainPageService, MainPageService>();
Services.AddScoped<IDiscountCodeService, DiscountCodeService>();
Services.AddScoped<IArticleCategoryService, ArticleCategoryService>();
Services.AddScoped<IArticleService, ArticleService>();
Services.AddScoped<IArticleCommentService, ArticleCommentService>();
Services.AddScoped<ICartService, CartService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/ErrorHandler/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/ErrorHandler/500");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
  name:"Default" , pattern:"{area:exists}/{Controller=Home}/{action=Index}/{id?}"
    );
app.Run();
