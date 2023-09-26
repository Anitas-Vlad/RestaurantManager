using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController :ControllerBase
{
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService) 
        => _accountService = accountService;

    [HttpGet]
    [Route("TotalEarnings")]
    public async Task<double> GetTotalEarnings() 
        => await _accountService.GetTotalEarnings();

    [HttpGet]
    [Route("Purchases")]
    public async Task<ActionResult<List<Purchase>>> GetAllPurchases() 
        => await _accountService.GetAllPurchases();
}