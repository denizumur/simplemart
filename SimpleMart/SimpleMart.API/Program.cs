using Microsoft.EntityFrameworkCore;
using SimpleMart.Application.Interfaces;
using SimpleMart.Application.Services;
using SimpleMart.Domain.Interfaces;
using SimpleMart.Infrastructure.Context;
using SimpleMart.Infrastructure.Repositories;
using SimpleMart.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// katman baðýmlýlýklarý
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper yok
var app = builder.Build();  

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
