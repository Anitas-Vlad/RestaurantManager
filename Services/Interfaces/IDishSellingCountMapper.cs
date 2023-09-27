using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface IDishSellingCountMapper
{
    DishSellingCountResponse Map(DishSellingCount dishSellingCount);
}