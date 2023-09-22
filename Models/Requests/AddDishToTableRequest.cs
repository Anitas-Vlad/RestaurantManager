using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Requests;

public class AddDishToTableRequest
{
    [Required] public int TableId { get; set; }
    [Required] public int DishId { get; set; }
    [Required] public int Quantity { get; set; }
}