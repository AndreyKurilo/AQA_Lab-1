using System.Collections.Generic;
using NLog;
using Npgsql;
using SQL_dataBase.Models;

namespace SQL_dataBase.Services;

public class EmployeeService
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public EmployeeService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<Employee> GetAllEmployees()
    {
        var employeeList = new List<Employee>();
        
        // Retrieve all rows
        using var cmd = new NpgsqlCommand("SELECT * FROM \"Employees\";", _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var employee = new Employee()
            {
                id = reader.GetInt32(0),
                firstname = reader.GetString(reader.GetOrdinal("firstname")),
                lastname = reader.GetString(reader.GetOrdinal("lastname")),
                age = reader.GetInt32(reader.GetOrdinal("age"))
            };
            
            _logger.Info(employee.ToString);
            
            employeeList.Add(employee);
        }
        
        return employeeList;
    }

    public int AddEmployee(Employee employee)
    {
        using var cmd = new NpgsqlCommand("INSERT INTO \"Employees\" (firstname, lastname, age) VALUES ($1, $2, $3);", _connection)
        {
            Parameters =
            {
                new() {Value = employee.firstname},
                new() {Value = employee.lastname},
                new () {Value = employee.age}
            }
        };

        return cmd.ExecuteNonQuery();
    }

    public int DeleteEmployee(Employee employee)
    {
        using var cmd = new NpgsqlCommand("DELETE FROM \"Employees\" WHERE firstname = $1 AND lastname = $2;", _connection)
        {
            Parameters =
            {
                new() {Value = employee.firstname},
                new() {Value = employee.lastname}
            }
        };

        return cmd.ExecuteNonQuery();
    }

}