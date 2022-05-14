using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Services;

namespace SpecFlowProjectForSQLdatabase.Steps;

[Binding]
public class EmployeesOperationsDefinition
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private EmployeeService? _employeeService;
    private SimpleDBConnector? _simpleDbConnector;
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
        ScenarioContext.StepIsPending();
    }
}