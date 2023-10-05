using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services.Mappers;

public class DishSellingCountMapper : IDishSellingCountMapper
{
    public DishSellingCountResponse Map(DishSellingCount dishSellingCount)
        => new()
        {
            Name = dishSellingCount.Name,
            Quantity = dishSellingCount.Quantity
        };

    public List<DishSellingCountResponse> Map(List<DishSellingCount> dishSellingCounts) 
        => dishSellingCounts.Select(dish => Map(dish)).ToList();
}