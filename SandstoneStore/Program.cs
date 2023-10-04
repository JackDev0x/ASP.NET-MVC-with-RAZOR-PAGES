using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SandstoneStore.Models;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SandstoneStoreConnestion"]); });
//builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SandstoneStoreConnestion"], builder => builder.EnableRetryOnFailure()); });

builder.Services.AddScoped<IDatabaseRepository, EFSandstonesRepository>();
builder.Services.AddScoped<IOrdersRepo, EFOrdersRepo>();

builder.Services.AddRazorPages();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped(localServices => SessionCart.GetCart(localServices));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


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

app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedExampleData.EnsurePopulated(app);

app.Run();
