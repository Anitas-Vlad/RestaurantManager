using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController :ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    [Route("TotalEarnings")]
    public async Task<double> GetTotalEarnings() 
        => await _accountService.GetTotalEarnings();

    [HttpGet]
    [Route("Purchases")]
    public async Task<ActionResult<List<PurchaseResponse>>> GetAllPurchases() 
        => await _accountService.GetAllPurchases();

    [HttpGet]
    [Route("OrderedDishSellingCounts")]
    public async Task<ActionResult<List<DishSellingCountResponse>>> GetOrderedDishSellingCounts()
        => await _accountService.GetOrderedDishSellingCounts();
}