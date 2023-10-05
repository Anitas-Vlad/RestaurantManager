using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class TableService : ITableService
{
    private readonly RestaurantManagementContext _context;
    private readonly IDishService _dishService;
    private readonly IAccountService _accountService;
    private readonly ITableDishService _tableDishService;

    public TableService(RestaurantManagementContext context, IDishService dishService, IAccountService accountService, ITableDishService tableDishService)
    {
        _context = context;
        _dishService = dishService;
        _accountService = accountService;
        _tableDishService = tableDishService;
    }

    public async Task<Table> ClearTable(int tableId)
    {
        var table = await QueryTableById(tableId);
            
        if (await CheckIfTableIsAvailable(tableId))
            throw new ArgumentException("Table is already empty.");

        await _accountService.CreatePurchase(table);

        table.TableDishes = new List<TableDish>();
        table.TotalPrice = 0;
        table.isAvailable = true;

        await _context.SaveChangesAsync();
        return table;
    }

    public async Task<List<Table>> QueryAllTables() =>
        await _context.Tables.Include(table => table.TableDishes)
            .ToListAsync();

    public async Task<Table> AddToTable(AddDishToTableRequest request)
    {
        var table = await QueryTableById(request.TableId);
        var tableDishFromDb = table.TableDishes.SingleOrDefault(tableDish => tableDish.DishId == request.DishId);

        if (request.Quantity == 0)
            throw new ArgumentException("Quantity must be larger than 0.");

        if (tableDishFromDb == null)
        {
            if (await CheckIfTableIsAvailable(table.Id)) 
                table.isAvailable = false;
            
            var newTableDish = await _tableDishService.CreateTableDish(request);
            
            table.TotalPrice += Math.Round(request.Quantity * newTableDish.Price, 2);
        
            table.TableDishes.Add(newTableDish);
            await _context.SaveChangesAsync();
            
            return table;
        }

        tableDishFromDb.Quantity += request.Quantity;
        table.TotalPrice += Math.Round(request.Quantity * tableDishFromDb.Price, 2);
        
        await _context.SaveChangesAsync();
        return table;
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

    private Task<bool> CheckIfTableIsAvailable(int tableId) =>
        Task.FromResult(!_context.Tables
            .Include(table => table.TableDishes)
            .Where(table => table.Id == tableId).Any(table => table.TableDishes.Any()));
}