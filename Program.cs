using Microsoft.EntityFrameworkCore;
using PersonalSectorManager.Models;
using PersonalSectorManager.Service;
using PersonalSectorManager.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITransformer, UserDataTransformer>();

var configuration = builder.Configuration;
builder.Services.AddDbContext<ProfileDBContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
