using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Context;

public class RestaurantManagementContext : DbContext
{
    public RestaurantManagementContext(DbContextOptions<RestaurantManagementContext> options) 
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelBuilderExtensions.Seed(modelBuilder);
    }

    public DbSet<Dish> Dishes { get; set; } = default!;
    public DbSet<Table> Tables { get; set; } = default!;
    public DbSet<TableDish> TableDishes { get; set; } = default!;
    public DbSet<Purchase> Purchases { get; set; } = default!;
    public DbSet<PurchasedDish> PurchasedDishes { get; set; } = default!;
    public DbSet<DishSellingCount> DishSellingCounts { get; set; } = default!;

    private static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Best Dish",
                    Price = 12.33
                },
                new Dish
                {
                    Id = 2,
                    Name = "Worst",
                    Price = 2.12
                },
                new Dish
                {
                    Id = 3,
                    Name = "Dutch Anger",
                    Price = 6.66
                },
                new Dish
                {
                    Id = 4,
                    Name = "Fishy Stuff",
                    Price = 12.33
                },
                new Dish
                {
                    Id = 5,
                    Name = "Moowie Woowie",
                    Price = 12.33
                }
            );
            modelBuilder.Entity<DishSellingCount>().HasData(
                new DishSellingCount
                {
                    Id = 1,
                    Name = "Best Dish",
                    DishId = 1,
                    Quantity = 0
                },
                new DishSellingCount
                {
                    Id = 2,
                    Name = "Worst",
                    DishId = 2,
                    Quantity = 0
                },
                new DishSellingCount
                {
                    Id = 3,
                    Name = "Dutch Anger",
                    DishId = 3,
                    Quantity = 0
                },
                new DishSellingCount
                {
                    Id = 4,
                    Name = "Fishy Stuff",
                    DishId = 4,
                    Quantity = 0
                },
                new DishSellingCount
                {
                    Id = 5,
                    Name = "Moowie Woowie",
                    DishId = 5,
                    Quantity = 0
                }
            );
            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    
                    Id = 1,
                    Number = 1,
                    isAvailable = true,
                    TableDishes = new List<TableDish>(),
                    TotalPrice = 0
                },
                new Table
                {
                    Id = 2,
                    Number = 2,
                    isAvailable = true,
                    TableDishes = new List<TableDish>(),
                    TotalPrice = 0
                },
                new Table
                {
                    Id = 3,
                    Number = 3,
                    isAvailable = true,
                    TableDishes = new List<TableDish>(),
                    TotalPrice = 0
                },
                new Table
                {
                    Id = 4,
                    Number = 4,
                    isAvailable = true,
                    TableDishes = new List<TableDish>(),
                    TotalPrice = 0
                },
                new Table
                {
                    Id = 5,
                    Number = 5,
                    isAvailable = true,
                    TableDishes = new List<TableDish>(),
                    TotalPrice = 0
                }
            );
        }
    }
}