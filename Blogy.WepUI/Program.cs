using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Blogy.WepUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogContext>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal,EfArticleDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal,EfCommentDal>();

builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();

builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();


builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("WriterAccessDenied", policy =>
    {
        policy.RequireRole("Writer"); 
        policy.RequireAuthenticatedUser(); 
        policy.AuthenticationSchemes.Add("Identity.Application"); 
    });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccessDenied", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireAuthenticatedUser(); 
        policy.AuthenticationSchemes.Add("Identity.Application"); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 403) 
    {
        context.Response.Redirect("/Account/AccessDenied.cshtml"); 
    }
});



var supportedCultures = new[] { "en", "fr", "es", "it", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
