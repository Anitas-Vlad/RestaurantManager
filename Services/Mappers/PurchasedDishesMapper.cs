using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services.Mappers;

public class PurchasedDishesMapper : IPurchasedDishesMapper
{
    public PurchasedDishResponse Map(PurchasedDish dish) =>
        new()
        {
            Name = dish.Name,
            DishId = dish.DishId,
            Quantity = dish.Quantity
        };

    public List<PurchasedDishResponse> Map(List<PurchasedDish> dishes) 
        => dishes.Select(Map).ToList();
}