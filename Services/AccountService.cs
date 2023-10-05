using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Context;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;

namespace RestaurantManagement.Services;

public class AccountService : IAccountService
{
    private readonly RestaurantManagementContext _context;
    private readonly IPurchaseService _purchaseService;
    private readonly IDIshSellingCountService _dishSellingCountService;
    private readonly IDishSellingCountMapper _dishSellingCountMapper;
    private readonly IPurchaseMapper _purchaseMapper;

    public AccountService(RestaurantManagementContext context, IPurchaseService purchaseService, 
        IDIshSellingCountService dishSellingCountService, IDishSellingCountMapper dishSellingCountMapper,
        IPurchaseMapper purchaseMapper)
    {
        _context = context;
        _purchaseService = purchaseService;
        _dishSellingCountService = dishSellingCountService;
        _dishSellingCountMapper = dishSellingCountMapper;
        _purchaseMapper = purchaseMapper;
    }

    public async Task CreatePurchase(Table table)
    {
        var purchase = new Purchase
        {
            PurchasedDishes = _purchaseService.CreatePurchasedDishes(table.TableDishes),
            TimeOfPurchase = DateTime.UtcNow,
            Total = Math.Round(table.TotalPrice, 2)
        };

         await _dishSellingCountService.UpdateDishSellingCount(purchase); //SOMETHING'S WRONG HERE
        
        _context.Purchases.Add(purchase);
    }

    public async Task<double> GetTotalEarnings() => 
        Math.Round((await _context.Purchases.Select(purchase => purchase.Total).ToListAsync()).Sum(), 2);

    public async Task<List<PurchaseResponse>> GetAllPurchases() => 
        _purchaseMapper.Map(await _context.Purchases.Include(p => p.PurchasedDishes).ToListAsync());

    public async Task<List<DishSellingCountResponse>> GetOrderedDishSellingCounts() =>
        _dishSellingCountMapper.Map(await _dishSellingCountService.OrderDishSellingCounts());
}