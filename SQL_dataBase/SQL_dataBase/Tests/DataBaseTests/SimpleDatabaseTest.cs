using System;
using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Models;
using SQL_dataBase.Services;

namespace SQL_dataBase.Tests.DataBaseTests;

public class SimpleDatabaseTest
{
    /*
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private CustomerService? _customerService;
    private SimpleDBConnector? _simpleDbConnector;
        
    [OneTimeSetUp]
    public void SetUpConnection()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customerService = new CustomerService(_simpleDbConnector.Connection);
    }

    [OneTimeTearDown]
    public void closeConnection()
    {
        _simpleDbConnector?.CloseConnection();
    }

    private Customer _customer = new Customer();

    [Test]
    [Order(1)]
    public void GetAllCustomersTest()
    {
        _logger.Info("GetAllCustomersTest started...");
        var customersList = _customerService?.GetAllCustomers();

        Assert.AreEqual(8, customersList.Count);

        _logger.Info("GetAllCustomersTest completed...");
    }

    [Test]
    [Order(2)]
    public void AddCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");

        Random randomNumber = new Random();

        _customer = new Customer
        {
            firstname = "Any" + randomNumber.Next(0, 1000),
            lastname = "Body",
            age = randomNumber.Next(0, 70)
        };
        
        Assert.AreEqual(1, _customerService?.AddCustomer(_customer));
        
        _logger.Info("AddCustomerTest completed...");
    }

    [Test]
    [Order(3)]
    public void DeleteCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        Assert.AreEqual(1, actual: _customerService?.DeleteCustomer(_customer));
        
        _logger.Info("AddCustomerTest completed...");
    }
    
    [Test]
    [Order(4)]
    public void DeleteCustomerTest1()
    {
        _logger.Info("AddCustomerTest started...");
        Assert.AreEqual(1, actual: _customerService?.DeleteCustomer(new Customer()
        {
            firstname = "Sergey687",
            lastname = "Ivanov"
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }
    */
}