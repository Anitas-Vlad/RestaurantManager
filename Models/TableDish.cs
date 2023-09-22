using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models;

public class TableDish
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public int TableId { get; set; }
    [Required] public int DishId { get; set; }
    [Required] public double Price { get; set; }
    [Required] public int Quantity { get; set; }
}