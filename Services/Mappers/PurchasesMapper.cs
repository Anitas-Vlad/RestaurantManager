using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services.Mappers;

public class PurchasesMapper :IPurchasesMapper
{ 
    public IPurchasedDishesMapper _purchasedDishesMapper;

    public PurchasesMapper(IPurchasedDishesMapper purchasedDishesMapper)
    {
        _purchasedDishesMapper = purchasedDishesMapper;
    }

    public PurchaseResponse Map(Purchase purchase)
        => new()
        {
            PurchasedDishes = _purchasedDishesMapper.Map(purchase.PurchasedDishes),
            TimeOfPurchase = purchase.TimeOfPurchase.ToString(),
            Total = purchase.Total
        };

    public List<PurchaseResponse> Map(List<Purchase> purchases)
        => purchases.Select(Map).ToList();
}