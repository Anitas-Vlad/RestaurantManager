using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Mappers;

public class TableDishMapper
{
    public TableDishResponse Map(TableDish dish)
        => new()
        {
            Name = dish.Name,
            DishId = dish.DishId,
            Price = dish.Price,
            Quantity = dish.Quantity,
            TableId = dish.TableId
        };

    public List<TableDishResponse> Map(IEnumerable<TableDish> dishes)
        => dishes.Select(Map).ToList();
}