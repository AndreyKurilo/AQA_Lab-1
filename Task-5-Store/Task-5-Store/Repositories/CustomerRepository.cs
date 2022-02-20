using Task_5_Store.Factories;
using Task_5_Store.Models;

namespace Task_5_Store.Repositories;

public class CustomerRepository
{
    private readonly List<Customer> _customers = new();
    private readonly CustomerFactory _customerFactory;

    public CustomerRepository(CustomerFactory customerFactory)
    {
        _customerFactory = customerFactory;
    }

    public Customer AddCustomer()
    {
        Customer customer = _customerFactory.Create();
        _customers.Add(customer);

        return customer;
    }

    public IEnumerable<Customer> GetCustomers() => _customers;
}