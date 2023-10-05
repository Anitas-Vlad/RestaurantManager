namespace RestaurantManagement.Services;

public class Test
{
    private int BaseNumber { get; set; }
    private string name { get; set; }
    
    public void BasePlus10()
    {
        BaseNumber += 10;
    }

    public void AddToBase(int numberToAdd) 
        => BaseNumber += numberToAdd;
}