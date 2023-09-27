using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class DishSellingCountService : IDIshSellingCountService
{
    private readonly RestaurantManagementContext _context;

    public DishSellingCountService(RestaurantManagementContext context)
    {
        _context = context;
    }
    
    public async Task<DishSellingCount> QueryDishSellingCountByPurchasedDish(PurchasedDish purchasedDish) => 
        await _context.DishSellingCounts.Where(dish => dish.DishId == purchasedDish.DishId).FirstAsync();

    public void CreateDishSellingCount(PurchasedDish purchasedDish)
    {
        _context.DishSellingCounts.Add(new DishSellingCount
        {
            Name = purchasedDish.Name,
            DishId = purchasedDish.DishId,
            Quantity = purchasedDish.Quantity
        });
    }
    
    public async Task UpdateDishSellingCount(Purchase purchase)
    {
        foreach (var purchasedDish in purchase.PurchasedDishes)
        {
            var dishSellingCountFromDb =
                await QueryDishSellingCountByPurchasedDish(purchasedDish);

            dishSellingCountFromDb.Quantity += purchasedDish.Quantity;
        }
    }
    
    public async Task<List<DishSellingCount>> OrderDishSellingCounts() =>
        await _context.DishSellingCounts.OrderBy(dish => dish.Quantity).Reverse().ToListAsync();
}