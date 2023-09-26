using RestaurantManagement.Models;

namespace RestaurantManagement.Services.Interfaces;

public interface IAccountService
{
    void CreatePurchase(Table table);
    Task<double> GetTotalEarnings();
    Task<List<Purchase>> GetAllPurchases();
}