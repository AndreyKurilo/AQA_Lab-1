using Bogus;
using Bogus.Bson;

namespace Store.Model;

public class Product
{
    public string Name { get; set; }
    public string Category {get; set;}
    public float Price { get; set; }
}