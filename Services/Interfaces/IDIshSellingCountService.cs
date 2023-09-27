using RestaurantManagement.Models;

namespace RestaurantManagement.Services.Interfaces;

public interface IDIshSellingCountService
{
    Task<DishSellingCount> QueryDishSellingCountByPurchasedDish(PurchasedDish purchasedDish);
    void CreateDishSellingCount(PurchasedDish purchasedDish);
    Task UpdateDishSellingCount(Purchase purchase);
    Task<List<DishSellingCount>> OrderDishSellingCounts();
}