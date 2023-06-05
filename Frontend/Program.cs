using CubeTimerData.Models;
using CubeTimerServices.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Server");
builder.Services.AddDbContext<CubeTimerContext>(options =>
{
    options.UseMySql(
        connectionString,
        new MariaDbServerVersion(ServerVersion.AutoDetect(connectionString)),
        x => x.MigrationsAssembly("CubeTimerData")
    );
});

builder.Services.AddSingleton<ScramblerService>();
builder.Services.AddScoped<SolvesService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/test", () => new { Test = "Hello"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
