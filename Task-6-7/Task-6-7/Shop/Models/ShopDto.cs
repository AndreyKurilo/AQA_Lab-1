using Task_6_7.Phones.Models;

namespace Task_6_7.Shop.Models;

[Serializable]
public class ShopDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PhoneDto> Phones { get; set; }
}