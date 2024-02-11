using Equitel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Equitel.Services.Contrato;
using Equitel.Services.Implementacion;
using AutoMapper;
using Equitel.DTOs;
using Equitel.Utilidades;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EquitelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultStringConnection"));
});

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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





app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
