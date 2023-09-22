using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Requests;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TablesController : ControllerBase
{
    private readonly ITableService _tableService;
    private readonly IDishService _dishService;
    
    public TablesController(ITableService tableService, IDishService dishService)
    {
        _tableService = tableService;
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Table>>> GetAlLTables() 
        => await _tableService.QueryAllTables();

    [HttpGet]
    [Route("{tableId}")]
    public async Task<ActionResult<Table>> GetTableById(int tableId) 
        => await _tableService.QueryTableById(tableId);

    [HttpPatch]
    public async Task AddDishToTable(AddDishToTableRequest request) 
        => await _tableService.AddToTable(request);
}