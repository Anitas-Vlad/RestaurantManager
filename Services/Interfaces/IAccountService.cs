using RestaurantManagement.Models;

namespace RestaurantManagement.Services.Interfaces;

public interface IAccountService
{
    Task CreatePurchase(Table table);
    Task<double> GetTotalEarnings();
    Task<List<Purchase>> GetAllPurchases();
    Task<List<DishSellingCount>> GetOrderedDishSellingCounts();
}