namespace Task_6_7.Phones.Models;

[Serializable]
public class PhoneDto
{
    public string Model { get; set; }
    public string OperationSystemType { get; set; }
    public string MarketLaunchDate { get; set; }
    public string Price { get; set; }
    public bool IsAvailable { get; set; }
    public int ShopId { get; set; }
}