using Business.Services;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region IoC Container
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IReviewerService, ReviewerService>();
builder.Services.AddScoped<IHobbyService, HobbyService>();
#endregion
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
