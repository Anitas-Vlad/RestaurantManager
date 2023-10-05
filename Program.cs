using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Services;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestaurantManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantManagementContext") ?? throw new InvalidOperationException("Connection string 'RestaurantManagementContext' not found.")));

// 
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ITableDishService, TableDishService>();
builder.Services.AddScoped<IDIshSellingCountService, DishSellingCountService>();
builder.Services.AddScoped<IDishSellingCountMapper, DishSellingCountsMapper>();
builder.Services.AddScoped<IPurchasedDishesMapper, PurchasedDishesMapper>();
builder.Services.AddScoped<IPurchasesMapper, PurchasesMapper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();