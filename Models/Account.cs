namespace RestaurantManagement.Models;

public class Account
{
    public int Id { get; set; }
    public List<Purchase> Purchases { get; set; }
    public double TotalEarnings { get; set; }
}