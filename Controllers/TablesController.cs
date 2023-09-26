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
    
    public TablesController(ITableService tableService)
    {
        _tableService = tableService;
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

    [HttpPatch]
    [Route("clear-table-{tableId}")]
    public async Task<ActionResult<Table>> ClearTable(int tableId)
        => await _tableService.ClearTable(tableId);
}