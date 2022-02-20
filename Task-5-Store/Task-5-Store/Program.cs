using Bogus;
using Task_5_Store.Models;
using Task_5_Store.Repositories;

namespace Task_5_Store;

public static class Program
{
    public static void Main()
    {
        var services = new Services();
        
        AddCustomers(
            services.CustomerRepository(), 
            5);
        
        SupplyBucketsFor(
            services.CustomerRepository().GetCustomers(), 
            services.ProductsRepository(), 
            10);

        ProgramLoop(services);
    }

    private static void ProgramLoop(Services services)
    {
        while (true)
        {
            services.Output().PrintMenu();

            var choice = services.Input().ReadNumber();

            switch (choice)
            {
                case 0:
                    services.Menu().HandleExit();
                    return;
                case 1:
                    services.Menu().HandlePrintCustomers();
                    break;
                case 2:
                    services.Menu().HandlePrintBucket();
                    break;
                case 3:
                    services.Menu().HandleAddNewCustomer();
                    break;
                case 4:
                    services.Menu().HandleAddProduct();
                    break;
                case 5:
                    break;
                default:
                    services.Output().PrintWrongMenuOperation();
                    break;
            }
        }
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