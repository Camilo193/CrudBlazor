using Application.Interfaces;
using Application.Main;
using Domain.Repository;
//using Entity.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Carvajal.Services.Shared;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddControllers()
            .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<PedidosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PedidosDB")));

//builder.Services.AddDbContext<PedidosContext>(options =>
//{
//    options.UseSqlServer(configuration.GetConnectionString("PedidosDB"));
//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});

builder.Services.AddScoped<IProductoApplication, ProductoApplication>();
builder.Services.AddScoped<IRepository<Producto>, Repository<Producto>>();

builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();

builder.Services.AddScoped<IPedidoApplication, PedidoApplication>();
builder.Services.AddScoped<IRepository<Pedido>, Repository<Pedido>>();

builder.Services.AddScoped<PedidosContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
