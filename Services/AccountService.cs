using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class AccountService : IAccountService
{
    private readonly RestaurantManagementContext _context;
    private readonly IPurchaseService _purchaseService;

    public AccountService(RestaurantManagementContext context, IPurchaseService purchaseService)
    {
        _context = context;
        _purchaseService = purchaseService;
    }

    public void CreatePurchase(Table table)
    {
        _context.Purchases.Add(
            new Purchase
            {
                PurchasedDishes = _purchaseService.CreatePurchasedDishes(table.TableDishes),
                TimeOfPurchase = DateTime.Today,
                Total = Math.Round(table.TotalPrice, 2)
            });
    }

    public async Task<double> GetTotalEarnings() => 
        (await _context.Purchases.Select(purchase => purchase.Total).ToListAsync()).Sum();

    public Task<List<Purchase>> GetAllPurchases() => _context.Purchases.Include(p => p.PurchasedDishes).ToListAsync();
}