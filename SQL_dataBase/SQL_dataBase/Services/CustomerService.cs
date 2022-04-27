using System;
using System.Collections.Generic;
using NLog;
using Npgsql;
using SQL_dataBase.Models;

namespace SQL_dataBase.Services;

public class CustomerService
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public CustomerService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<Customer> GetAllCustomers()
    {
        var customersList = new List<Customer>();
        
        // Retrieve all rows
        using var cmd = new NpgsqlCommand("SELECT * FROM \"Customers\";", _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var customer = new Customer
            {
                id = reader.GetInt32(0),
                firstname = reader.GetString(reader.GetOrdinal("firstname")),
                lastname = reader.GetString(reader.GetOrdinal("lastname")),
                age = reader.GetInt32(reader.GetOrdinal("age"))
            };
            
            _logger.Info(customer.ToString);
            
            customersList.Add(customer);
        }
        
        return customersList;
    }

    public int AddCustomer(Customer customer)
    {
        using var cmd = new NpgsqlCommand("INSERT INTO \"Customers\" (firstname, lastname, age) VALUES ($1, $2, $3);", _connection)
        {
            Parameters =
            {
                new() {Value = customer.firstname},
                new() {Value = customer.lastname},
                new () {Value = customer.age}
            }
        };

        return cmd.ExecuteNonQuery();
    }

    public int DeleteCustomer(Customer customer)
    {
        using var cmd = new NpgsqlCommand("DELETE FROM \"Customers\" WHERE firstname = $1 AND lastname = $2;", _connection)
        {
            Parameters =
            {
                new() {Value = customer.firstname},
                new() {Value = customer.lastname}
            }
        };

        return cmd.ExecuteNonQuery();
    }
}