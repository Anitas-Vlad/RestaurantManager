using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;

namespace RestaurantManagement.Services.Interfaces;

public interface ITableService
{
    void ClearTable(int tableId);
    Task<List<Table>> QueryAllTables();
    Task<Table> AddToTable(AddDishToTableRequest request);
    Task<Table> QueryTableById(int tableId);
}