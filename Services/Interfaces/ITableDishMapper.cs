using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface ITableDishMapper
{
    TableDishResponse Map(TableDish dish);
    List<TableDishResponse> Map(IEnumerable<TableDish> dishes);
}