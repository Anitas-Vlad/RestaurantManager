using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Responses;

public class PurchaseResponse
{
    [Required] public List<PurchasedDishResponse> PurchasedDishes { get; set; }
    [Required] public string TimeOfPurchase { get; set; }
    [Required] public double Total { get; set; }
}