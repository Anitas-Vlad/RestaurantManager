using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models;

public class Table
{
    public int Id { get; set; }
    [Required] public int Number { get; set; }
    [Required] public bool isAvailable { get; set; }
    [Required] public List<TableDish> TableDishes { get; set; }
    [Required] public double TotalPrice { get; set; }
}