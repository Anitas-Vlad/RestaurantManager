using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Responses;

public class PurchasedDishResponse
{
    [Required] public string Name { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public int DishId { get; set; }
}