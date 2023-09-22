using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models;

public class Dish
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public double Price { get; set; }
}