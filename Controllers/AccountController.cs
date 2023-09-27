using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController :ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IDishSellingCountMapper _dishSellingCountMapper;

    public AccountController(IAccountService accountService, IDishSellingCountMapper dishSellingCountMapper)
    {
        _accountService = accountService;
        _dishSellingCountMapper = dishSellingCountMapper;
    }

    [HttpGet]
    [Route("TotalEarnings")]
    public async Task<double> GetTotalEarnings() 
        => await _accountService.GetTotalEarnings();

    [HttpGet]
    [Route("Purchases")]
    public async Task<ActionResult<List<Purchase>>> GetAllPurchases() 
        => await _accountService.GetAllPurchases();

    [HttpGet]
    [Route("OrderedDishSellingCounts")]
    public async Task<ActionResult<List<DishSellingCount>>> GetOrderedDishSellingCounts()
        => await _accountService.GetOrderedDishSellingCounts();
}