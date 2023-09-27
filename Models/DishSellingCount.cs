using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models;

public class DishSellingCount
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public int DishId { get; set; }
}