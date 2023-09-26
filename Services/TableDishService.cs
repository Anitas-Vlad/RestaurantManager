using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class TableDishService : ITableDishService
{
    private readonly IDishService _dishService;

    public TableDishService(IDishService dishService)
    {
        _dishService = dishService;
    }
    
    public async Task<TableDish> CreateTableDish(AddDishToTableRequest request)
    {
        var dish = await _dishService.QueryDishById(request.DishId);

        var tableDish = new TableDish
        {
            Name = dish.Name,
            TableId = request.TableId,
            DishId = dish.Id,
            Quantity = request.Quantity,
            Price = dish.Price
        };
        return tableDish;
    }
}