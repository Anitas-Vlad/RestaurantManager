using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class DishService : IDishService
{
    private readonly RestaurantManagementContext _context;

    public DishService(RestaurantManagementContext context)
    {
        _context = context;
    }
    
    public async Task<Dish> QueryDishById(int dishId)
    {
        var dish = await _context.Dishes
            .Where(table => table.Id == dishId)
            .SingleOrDefaultAsync();
        
        if (dish == null)
            throw new ArgumentException("No dish was found.");
        
        return dish;
    }

    public async Task<List<Dish>> QueryAllDishes()
        => await _context.Dishes.ToListAsync();
}