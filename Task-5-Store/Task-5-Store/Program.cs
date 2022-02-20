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
        var productFactory = new ProductFactory(productData);
        
        AddCustomers(customerRepository, 5);
        SupplyBucketsFor(customerRepository.GetCustomers(), productFactory, 10);

        var customers = customerRepository.GetCustomers();
    }

    private static void SupplyBucketsFor(IEnumerable<Customer> customers, ProductFactory productFactory, int count)
    {
        foreach (Customer customer in customers)
        {
            Bucket bucket = customer.Bucket;

            for (var i = 0; i < count; i++)
            {
                bucket.AddProduct(productFactory.CreateRandom());
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