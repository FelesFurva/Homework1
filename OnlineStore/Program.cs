using DataAccess.Context;
using OnlineStore;
using Microsoft.EntityFrameworkCore;
using OnlineStoreServices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ISubCategoryManager, SubCategoryManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ICartManager, CartManager>();
builder.Services.AddScoped<IOrderManager, OrderManager > ();
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
