using Task_5_Store.Models;

namespace Task_5_Store;

public class Menu
{
    private readonly Services _services;

    public Menu(Services services)
    {
        _services = services;
    }

    public void HandleExit()
    {
        _services.Output().PrintGoodbyeMessage();
    }

    public void HandlePrintCustomers()
    {
        _services
            .Output()
            .PrintCustomers(_services.CustomerRepository().GetCustomers());
    }

    public void HandlePrintBucket()
    {
        _services
            .Output()
            .PrintCustomers(_services.CustomerRepository().GetCustomers());

        _services.Output().PrintCustomerSelection();

        int choice;

        while (true)
        {
            choice = _services.Input().ReadNumber() - 1;

            if (choice >= 0 && choice < _services.CustomerRepository().GetCustomers().Count())
            {
                break;
            }

            _services.Output().PrintWrongIndexMessage();
        }

        var customers = _services.CustomerRepository().GetCustomers();
        Customer customer = customers.ToList().ElementAt(choice);

        _services.Output().PrintBucket(customer.Bucket, customer);
    }

    public void HandleAddNewCustomer()
    {
        _services.Output().PrintEnterNameMessage();
        var fullname = _services.Input().ReadLine();

        _services.Output().PrintEnterAgeMessage();
        var age = _services.Input().ReadNumberInRange(1, 100);

        while (true)
        {
            _services.Output().PrintEnterPassportIdMessage();
            var passportId = _services.Input().ReadNumberInRange(1, int.MaxValue);

            var customer = new Customer(passportId, fullname, age);

            var customers = _services.CustomerRepository().GetCustomers();
            var users = new List<User>(customers);

            if (!_services.Validation().IsAlreadyExists(customer, users))
            {
                _services.CustomerRepository().AddCustomer(customer);
                break;
            }

            _services.Output().PrintSameUserIdMessage(customer);
        }
    }

    public void HandleAddProduct()
    {
        var customers = _services.CustomerRepository().GetCustomers().ToList();
        _services.Output().PrintCustomers(customers);

        _services.Output().PrintEnterCustomerIndex();

        var index = _services.Input().ReadNumberInRange(1, customers.Count()) - 1;

        Customer customer = customers.ToList().ElementAt(index);
        var bucket = customer.Bucket;

        var categories = _services.ProductsData().GetCategories().ToList();
        _services.Output().PrintCollection(categories);
        _services.Output().PrintEnterCategoryMessage();

        index = _services.Input().ReadNumberInRange(1, categories.Count) - 1;

        var category = categories.ElementAt(index);

        var productsNames = _services.ProductsData().GetProductsNames(category).ToList();

        _services.Output().PrintCollection(productsNames);
        _services.Output().PrintEnterProductMessage();

        index = _services.Input().ReadNumberInRange(1, productsNames.Count) - 1;

        var productName = productsNames.ElementAt(index);

        Product? product = _services.ProductsRepository().GetProductByName(productName);

        if (product == null)
        {
            _services.Output().PrintNoSuchProductMessage(productName);
            return;
        }

        if (_services.Validation().CanBuyAlcohol(customer, product))
        {
            bucket.AddProduct(product);
            _services.Output().PrintProductAdded();
        }
        else
        {
            _services.Output().PrintAlcoholProhibition(customer);
        }
    }

    public void HandleRemoveProduct()
    {
        var customers = _services.CustomerRepository().GetCustomers().ToList();
        _services.Output().PrintCustomers(customers);

        _services.Output().PrintEnterCustomerIndex();

        var index = _services.Input().ReadNumberInRange(1, customers.Count()) - 1;

        Customer customer = customers.ToList().ElementAt(index);
        var bucket = customer.Bucket;

        _services.Output().PrintBucket(bucket, customer);
        _services.Output().PrintEnterBucketPositionMessage();

        var bucketProducts = bucket.GetProducts().ToList();
        
        index = _services.Input().ReadNumberInRange(1, bucketProducts.Count) - 1;

        var isRemoved = bucket.RemoveProduct(index);

        if (isRemoved)
        {
            _services.Output().PrintProductRemovedMessage();
        }
        else
        {
            _services.Output().PrintProductNotRemovedMessage();
        }
    }
}