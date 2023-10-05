using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services.Mappers;

public class PurchasedDishMapper : IPurchasedDishMapper
{
    public PurchasedDishResponse Map(PurchasedDish dish) =>
        new()
        {
            Name = dish.Name,
            Quantity = dish.Quantity
        };

    public List<PurchasedDishResponse> Map(List<PurchasedDish> dishes) 
        => dishes.Select(Map).ToList();
}