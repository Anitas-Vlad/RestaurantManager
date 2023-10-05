using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services.Mappers;

public class PurchaseMapper :IPurchaseMapper
{ 
    public IPurchasedDishMapper _purchasedDishMapper;

    public PurchaseMapper(IPurchasedDishMapper purchasedDishMapper)
    {
        _purchasedDishMapper = purchasedDishMapper;
    }

    public PurchaseResponse Map(Purchase purchase)
        => new()
        {
            PurchasedDishes = _purchasedDishMapper.Map(purchase.PurchasedDishes),
            TimeOfPurchase = purchase.TimeOfPurchase.ToString(),
            Total = purchase.Total
        };

    public List<PurchaseResponse> Map(List<Purchase> purchases)
        => purchases.Select(Map).ToList();
}