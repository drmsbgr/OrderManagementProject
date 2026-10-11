using Microsoft.EntityFrameworkCore;
using OrderManagement.Api;
using OrderManagement.Business.Contracts;
using OrderManagement.Business.Managers;
using OrderManagement.Core.Dtos;
using OrderManagement.Data;
using OrderManagement.Data.Contracts;
using OrderManagement.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), opt => opt.MigrationsAssembly("OrderManagement.Api")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("openapi/test.json");

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management API V1");
    });
}

app.UseHttpsRedirection();

app.MapPost("api/products", async (IProductService productService, ProductCreateDto prodCreateDto) =>
{
    await productService.CreateProductAsync(prodCreateDto);
    return Results.Created();
});

app.MapGet("api/products", async (IProductService productService) =>
{
    var products = await productService.GetAllProductsAsync();

    if (products.Count == 0)
        return Results.NotFound(new ApiResponse("Hiç ürün bulunamadı."));
    else
        return Results.Ok(new ApiResponse<ICollection<ProductDto>>("Ürünler getirildi.", products));

}).WithDisplayName("GetProducts");

app.Run();

