using System;
using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Models;
using SQL_dataBase.Services;

namespace SQL_dataBase.Tests.DataBaseTests;

public class SimpleEmployeesTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private EmployeeService? _employeeService;
    private SimpleDBConnector? _simpleDbConnector;
    private int _employeesCount;
        
    [OneTimeSetUp]
    public void SetUpConnection()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _employeeService = new EmployeeService(_simpleDbConnector.Connection);
    }

    [OneTimeTearDown]
    public void closeConnection()
    {
        _simpleDbConnector?.CloseConnection();
    }

    private Employee _employee = new Employee();
    

    [Test]
    [Order(1)]
    public void GetAllEmployeesTest()
    {
        _logger.Info("GetAllEmployeesTest started...");
        var employeesList = _employeeService?.GetAllEmployees();

        Assert.AreEqual(4, employeesList.Count);

        _logger.Info("GetAllEmployeesTest completed...");
    }

    [Test]
    [Order(2)]
    public void AddEmployeeTest()
    {
        _logger.Info("AddEmployeeTest started...");

        Random randomNumber = new Random();

        _employee = new Employee()
        {
            firstname = "Any" + randomNumber.Next(0, 1000),
            lastname = "Body",
            age = randomNumber.Next(0, 70)
        };
        
        Assert.AreEqual(1, _employeeService?.AddEmployee(_employee));
        
        _logger.Info("AddEmployeeTest completed...");
    }
    
    [Test]
    [Order(3)]
    public void GetAllEmployeesAfterAddEmployeeTest()
    {
        _logger.Info("GetAllEmployeesTest started...");
        var employeesList = _employeeService?.GetAllEmployees();

        Assert.AreEqual(5, employeesList.Count);

        _logger.Info("GetAllEmployeesTest completed...");
    }


    [Test]
    [Order(4)]
    public void DeleteEmployeeTest()
    {
        _logger.Info("DeleteEmployeeTest started...");
        Assert.AreEqual(1, actual: _employeeService?.DeleteEmployee(_employee));
        
        _logger.Info("DeleteEmployeeTest completed...");
    }
    
    [Test]
    [Order(5)]
    public void GetAllCustomersFinishTest()
    {
        _logger.Info("GetAllEmployeesTest started...");
        var employeesList = _employeeService?.GetAllEmployees();

        Assert.AreEqual(4, employeesList.Count);

        _logger.Info("GetAllEmployeesTest completed...");
    }
}