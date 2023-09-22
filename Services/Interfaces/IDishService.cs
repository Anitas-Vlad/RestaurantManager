using RestaurantManagement.Models;

namespace RestaurantManagement.Services.Interfaces;

public interface IDishService
{
    Task<Dish> QueryDishById(int dishId);
    Task<List<Dish>> QueryAllDishes();
}