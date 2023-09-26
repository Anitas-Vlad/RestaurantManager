namespace RestaurantManagement.Models;

public class Purchase
{
    public int Id { get; set; }
    public List<PurchasedDish> PurchasedDishes { get; set; }
    public DateTime TimeOfPurchase { get; set; }
    public double Total { get; set; }
}