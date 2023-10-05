using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface IAccountService
{
    Task CreatePurchase(Table table);
    Task<double> GetTotalEarnings();
    Task<List<PurchaseResponse>> GetAllPurchases();
    Task<List<DishSellingCountResponse>> GetOrderedDishSellingCounts();
}