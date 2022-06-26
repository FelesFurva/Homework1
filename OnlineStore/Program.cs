using DataAccess.Context;
using OnlineStore;
using Microsoft.EntityFrameworkCore;
using OnlineStoreServices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddDbContext<WebShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDb"));
});
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
