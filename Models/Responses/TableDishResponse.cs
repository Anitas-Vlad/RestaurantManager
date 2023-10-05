using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Responses;

public class TableDishResponse
{
    [Required] public string Name { get; set; }
    [Required] public int TableId { get; set; }
    [Required] public int DishId { get; set; }
    [Required] public double Price { get; set; }
    [Required] public int Quantity { get; set; }
}