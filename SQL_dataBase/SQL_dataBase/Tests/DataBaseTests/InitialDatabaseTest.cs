using System;
using System.Linq;
using NLog;
using NUnit.Framework;
using SQL_dataBase.Databases;
using SQL_dataBase.Models;

//using NUnit.Allure.Attributes;

namespace SQL_dataBase.Tests.DataBaseTests;

//[AllureSuite("DataBase Tests")]
public class InitialDatabaseTest
{
    private readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    [Test]
    public void DB_Test1()
    {
        using (var dbConnector = new DataBaseConnector())
        {
            Random randomNumber = new Random();

            var customer1 = new Customer { firstname = "Ivan" + randomNumber.Next(0, 1000), lastname = "FromInit", age = randomNumber.Next(1, 100)};
            var customer2 = new Customer { firstname = "Sergey" + randomNumber.Next(0, 1000), lastname = "Ivanov", age = randomNumber.Next(1, 100)};

            var entityCustomer1 = dbConnector.Customers.Add(customer1);
            var entityCustomer2 = dbConnector.Customers.Add(customer2);
            dbConnector.SaveChanges();

            var customers = dbConnector.Customers.ToList();
            _logger.Info("Customers List:");

            _logger.Info(
                $"{dbConnector.Customers.Find(entityCustomer2.Entity.id)?.firstname}" +
                $".{dbConnector.Customers.Find(entityCustomer2.Entity.id)?.lastname}" +
                $".{dbConnector.Customers.Find(entityCustomer2.Entity.id)?.age}");

           /* foreach (var customer in customers)
            {
                _logger.Info($"{customer.firstname}.{customer.lastname}.{customer.age}");
                dbConnector.Customers.Remove(customer);
            }*/
           dbConnector.Customers.Remove(customer1);
           dbConnector.Customers.Remove(customer2);
           dbConnector.SaveChanges();
        }

        Assert.True(true, "Test passed.");
    }
}