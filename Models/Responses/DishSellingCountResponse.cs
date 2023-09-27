using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Responses;

public class DishSellingCountResponse
{
    [Required] public string Name { get; set; }
    [Required] public int Quantity { get; set; }
}