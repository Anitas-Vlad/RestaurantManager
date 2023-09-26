using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;

namespace RestaurantManagement.Services.Interfaces;

public interface ITableDishService
{
    Task<TableDish> CreateTableDish(AddDishToTableRequest request);
}