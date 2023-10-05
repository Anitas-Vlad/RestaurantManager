using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface IPurchasedDishMapper
{
    PurchasedDishResponse Map(PurchasedDish dish);
    List<PurchasedDishResponse> Map(List<PurchasedDish> purchasePurchasedDishes);
}