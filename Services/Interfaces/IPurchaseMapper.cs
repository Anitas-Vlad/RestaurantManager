using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface IPurchaseMapper
{
    PurchaseResponse Map(Purchase purchase);
    List<PurchaseResponse> Map(List<Purchase> purchases);
}