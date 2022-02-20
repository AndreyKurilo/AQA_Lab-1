﻿using Task_5_Store.Models;

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
}