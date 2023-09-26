using RestaurantManagement.Models;

namespace RestaurantManagement.Services.Interfaces;

public interface IPurchaseService
{
    List<PurchasedDish> CreatePurchasedDishes(IEnumerable<TableDish> tableDishes);
}