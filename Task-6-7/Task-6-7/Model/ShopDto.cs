namespace Task_6_7.Model;

[Serializable]
public class ShopDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PhoneDto> Phones { get; set; }
}