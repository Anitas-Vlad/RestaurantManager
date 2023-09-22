using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class TableService : ITableService
{
    private readonly RestaurantManagementContext _context;
    private readonly IDishService _dishService;

    public TableService(RestaurantManagementContext context, IDishService dishService)
    {
        _context = context;
        _dishService = dishService;
    }

    public void ClearTable(int tableId)
    {
        throw new NotImplementedException();
    }

    public double CalculateTableTotal(int tableId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Table>> QueryAllTables() =>
        await _context.Tables.Include(table => table.TableDishes)
            .ToListAsync();

    public async Task<Table> AddToTable(AddDishToTableRequest request)
    {
        var table = await QueryTableById(request.TableId);
        var newTableDish = await CreateTableDish(request);

        // var price = request.Quantity * newTableDish.Price; // THIS
        table.TotalPrice += request.Quantity * newTableDish.Price; // THIS
        
        table.TableDishes.Add(newTableDish);

        await _context.SaveChangesAsync();
        return table;
    }

    private async Task<TableDish> CreateTableDish(AddDishToTableRequest request)
    {
        var dish = await _dishService.QueryDishById(request.DishId); // THIS

        var tableDish = new TableDish // THIS
        {
            Name = dish.Name,
            TableId = request.TableId,
            DishId = dish.Id,
            Quantity = request.Quantity,
            Price = dish.Price
        };
        return tableDish;
    }

    public async Task<Table> QueryTableById(int tableId)
    {
        var table = await _context.Tables
            .Include(table => table.TableDishes)
            .Where(table => table.Id == tableId)
            .SingleOrDefaultAsync();

        if (table == null)
            throw new ArgumentException("No table was found.");

        return table;
    }
}