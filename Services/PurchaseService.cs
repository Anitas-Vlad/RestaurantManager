using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class PurchaseService : IPurchaseService
{
    public List<PurchasedDish> CreatePurchasedDishes(IEnumerable<TableDish> tableDishes)
        => tableDishes.Select(dish => 
            new PurchasedDish { Name = dish.Name, Quantity = dish.Quantity })
            .ToList();
}