using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class DishesController
{
    private readonly IDishService _dishService;
    
    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Dish>>> GetAlLTables() 
        => await _dishService.QueryAllDishes();
    
    [HttpGet]
    [Route("{dishId}")]
    public async Task<ActionResult<Dish>> GetTableById(int dishId) 
        => await _dishService.QueryDishById(dishId);
    
    
}