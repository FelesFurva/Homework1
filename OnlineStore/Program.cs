using DataAccess.Context;
using OnlineStore;
using Microsoft.EntityFrameworkCore;
using OnlineStoreServices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddTransient<ISubCategoryManager, SubCategoryManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddTransient<ICartManager, CartManager>();
builder.Services.AddDbContext<WebShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDb"));
});

var app = builder.Build();
 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
