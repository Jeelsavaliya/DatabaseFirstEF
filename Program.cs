using DatabaseFirstEF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var provide = builder.Services.BuildServiceProvider();
var config = provide.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<DatabaseFirstDbContext>(item => item.UseSqlServer(config.GetConnectionString("myConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
