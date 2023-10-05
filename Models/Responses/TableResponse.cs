using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Responses;

public class TableResponse
{
    public int Id { get; set; }
    [Required] public int Number { get; set; }
    [Required] public bool IsAvailable { get; set; }
    [Required] public List<TableDishResponse> TableDishes { get; set; }
    [Required] public double TotalPrice { get; set; }
}