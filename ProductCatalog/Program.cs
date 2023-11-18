using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using PC.BL;
using PC.DAL;
using System.Security.Claims;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region repo
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();

#endregion

#region Managers
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();

#endregion

#region Database
builder.Services.AddDbContext<ProductCatalogContext>(options => options
.UseSqlServer(@"Server=.;Database=ProductCatalogDB;Trusted_Connection=true;Encrypt=false"));
#endregion

#region Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.User.RequireUniqueEmail = true;

    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}).AddEntityFrameworkStores<ProductCatalogContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "MyCookie";
    options.DefaultChallengeScheme = "MyCookie";
    options.DefaultSignInScheme = "MyCookie";
}
).AddCookie("MyCookie", options => { options.LoginPath = "/User/login"; });
#endregion

#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});
#endregion

var app = builder.Build();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=CurrentP}/{id?}");

app.Run();
