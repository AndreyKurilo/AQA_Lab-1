using Bogus;
using Task_5_Store.Data;
using Task_5_Store.Factories;
using Task_5_Store.Models;
using Task_5_Store.Repositories;

namespace Task_5_Store;

public static class Program
{
    public static void Main()
    {
        var productData = new ProductsData();
        var customerFactory = new CustomerFactory();
        var customerRepository = new CustomerRepository(customerFactory);
        var productFactory = new ProductFactory();
        var productRepository = new ProductsRepository(productData, productFactory);
        
        AddCustomers(customerRepository, 5);
        SupplyBucketsFor(customerRepository.GetCustomers(), productRepository, 10);
    }

    private static void SupplyBucketsFor(IEnumerable<Customer> customers, ProductsRepository productRepository, int quantity)
    {
        foreach (Customer customer in customers)
        {
            Bucket bucket = customer.Bucket;
            var faker = new Faker();

            for (var i = 0; i < quantity; i++)
            {
                Product? product = faker.PickRandom(productRepository.GetProducts());
                bucket.AddProduct(product);
            }
        }
    }

    private static void AddCustomers(CustomerRepository customerRepository, int count)
    {
        for (var i = 0; i < count; i++)
        {
            customerRepository.AddCustomer();
        }
    }
}