using Microsoft.EntityFrameworkCore;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.BusinessLayer.ServiceClasses;
using YummyFoods.DatabaseLayer.RepositoriesClasses;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<YummyFoodsDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAdminAuthenticationService, AdminAuthenticationService>();
builder.Services.AddTransient<IAdminAuthentication, AdminAuthentication>();
builder.Services.AddTransient<IProduct, Product>();
builder.Services.AddTransient<IProductServices, ProductServcies>();
builder.Services.AddTransient<ICategories, Categories>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IOffersCoupon, OffersCoupon>();
builder.Services.AddTransient<IOfferCouponService, OffersCouponService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1000); // Set session timeout
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminAuthorization}/{action=AdminLogin}/{id?}");

app.Run();
