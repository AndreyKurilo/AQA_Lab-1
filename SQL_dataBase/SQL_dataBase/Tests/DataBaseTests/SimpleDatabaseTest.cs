using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Models;
using SQL_dataBase.Services;

namespace SQL_dataBase.Tests.DataBaseTests;

public class SimpleDatabaseTest
{
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
    
    [Test]
    public void GetAllCustomersTest()
    {
        _logger.Info("GetAllCustomersTest started...");
        var customersList = _customerService?.GetAllCustomers();

        Assert.AreEqual(4, customersList.Count);

        _logger.Info("GetAllCustomersTest completed...");
    }

    [Test]
    public void AddCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        Assert.AreEqual(1, _customerService?.AddCustomer(new Customer
        {
            firstname = "Alexandr",
            lastname = "Trostyanko"
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }

    [Test]
    public void DeleteCustomerTest()
    {
        _logger.Info("AddCustomerTest started...");
        
        Assert.AreEqual(1, _customerService?.DeleteCustomer(new Customer
        {
            firstname = "Alexandr",
            lastname = "Trostyanko"
        }));
        
        _logger.Info("AddCustomerTest completed...");
    }
}