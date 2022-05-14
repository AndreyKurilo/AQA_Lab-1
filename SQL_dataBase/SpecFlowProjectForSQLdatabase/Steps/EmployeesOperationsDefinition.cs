using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Models;
using SQL_dataBase.Services;

namespace SpecFlowProjectForSQLdatabase.Steps;

[Binding]
public class EmployeesOperationsDefinition
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private EmployeeService? _employeeService;
    private SimpleDBConnector? _simpleDbConnector;
    private Employee _employee = new();
    private int _employeesCount;

    [Given(@"Setting up Connection")]
    public void GivenSetUpConnection()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _employeeService = new EmployeeService(_simpleDbConnector.Connection);
    }


    [Given(@"Count of employees equal (.*)")]
    public void GivenCountOfEmployeesEqual(int count)
    {
        var employeesList = _employeeService?.GetAllEmployees();
        _employeesCount = employeesList.Count;

        Assert.AreEqual(count, _employeesCount);
    }

    [When(@"Add employee to list")]
    public void WhenAddEmployeeToList()
    {
        Random randomNumber = new Random();
        _employee = new Employee()
        {
            firstname = "Any" + randomNumber.Next(0, 1000),
            lastname = "Body",
            age = randomNumber.Next(0, 70)
        };

        _employeeService.AddEmployee(_employee);
    }

    [Then(@"Count of employees increases on (.*)")]
    public void ThenCountOfEmployeesIncreasesOn(int addedEmployeeCount)
    {
        Assert.AreEqual(_employeesCount + addedEmployeeCount, _employeeService.GetAllEmployees().Count);
        _employeesCount += addedEmployeeCount;
    }

    [When(@"Delete employee from list")]
    public void WhenDeleteEmployeeFromList()
    {
        _employeeService.DeleteEmployee(_employee);
    }

    [Then(@"Count of employees decreases on (.*)")]
    public void ThenCountOfEmployeesDecreasesOn(int deletedEmployeeCount)
    {
        Assert.AreEqual(_employeesCount - deletedEmployeeCount, _employeeService.GetAllEmployees().Count);
    }

    [Given(@"Closing connection to database")]
    public void GivenClosingConnectionToDatabase()
    {
        _simpleDbConnector?.CloseConnection();
    }
}