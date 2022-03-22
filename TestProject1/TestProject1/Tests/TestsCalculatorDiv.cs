using System;
using System.Collections;
using NUnit.Framework;

namespace TestProject1.Tests;

public class TestsCalculatorDiv
{
    private Calculator _calculator;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.Out.WriteLineAsync("OneTimeSetup is started");
        _calculator = new Calculator();
    }

    [SetUp]
    public void Setup()
    {
        Console.Out.WriteLineAsync("Setup before test started");
    }

    [Test]
    [Category("SmokeTest")]
    [Property("Severity", 1)]
    public void TestPositiveIntNumbersDivision()
    {
        //Act
        var result = _calculator.Div(6, 2);
        
        // Assert
        Assert.AreEqual(3, result);
    }

    [TestCase(14, 4, 3.5)]
    [TestCase(9.3,3, 3.1)]
    [TestCase(29.61, 6.3, 4.7)]
    public void TestPositiveDoubleNumbersDiv(double a, double b, double expectedResult)
    {
        // Act
        var result = _calculator.Div(a, b);
        
        // Assert
        Assert.AreEqual(expectedResult, result, "Result of division doesn't equal to expected");
    }
    
    [TestCase(14, -4, -3.5)]
    [TestCase(9.3,-3, -3.1)]
    [TestCase(29.61, -6.3, -4.7)]
    public void TestPositiveDoubleNumbersDivNegativeNumber(double a, double b, double expectedResult)
    {
        // Act
        var result = _calculator.Div(a, b);
        
        // Assert
        Assert.AreEqual(expectedResult, result, "Result of division doesn't equal to expected");
    }
    
    [TestCase(-14, -4, 3.5)]
    [TestCase(-9.3,-3, 3.1)]
    [TestCase(-29.61, -6.3, 4.7)]
    public void TestNegativeNumbersDivision(double a, double b, double expectedResult)
    {
        // Act
        var result = _calculator.Div(a, b);
        
        // Assert
        Assert.AreEqual(expectedResult, result, "Result of division doesn't equal to expected");
    }



    [TestCaseSource(typeof(TestsCalculatorDiv), nameof(NumbersForTest))]
    public void TestIntegersDivisionWithDobleResult(Tuple<int, int, double> numbers)
    {
        // Act
        var result = _calculator.Div(numbers.Item1, numbers.Item2);

        // Assert
        Assert.AreEqual(numbers.Item3, result);
    }

    public static IEnumerable NumbersForTest()
    {
        yield return new Tuple<int, int, double>(48, 3, 16);
        yield return new Tuple<int, int, double>(60, 15, 4);
        yield return new Tuple<int, int, double>(27, 3, 9.0);
        yield return new Tuple<int, int, double>(22, 22, 1.0);
    }
    
    [Test]
    [Property("Priority", 2)]
    public void TestDivZero()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<DivideByZeroException>(
                delegate { _calculator.Div(8, 0); });

            Assert.Throws<DivideByZeroException>(
                () => { _calculator.Div(7, 0); });

            TestDelegate divByZero = () => _calculator.Div(6, 0);

            Assert.Throws<DivideByZeroException>(divByZero);
        });
    }
    
    [Test]
    public void TestDoubleDiv()
    {
        Assert.Multiple(() =>
        {
            double a = TestContext.CurrentContext.Random.NextDouble(100);
            double b = TestContext.CurrentContext.Random.NextDouble(10, 20);

            TestContext.Out.WriteLineAsync("First Double is " + a);
            TestContext.Out.WriteLineAsync($"Second Double is {b}");
            Assert.AreEqual(a / b, _calculator.Div(a, b));
            Assert.AreEqual(3.7737556561085972d, _calculator.Div(8.34, 2.21));
            Assert.True(Double.IsPositiveInfinity(_calculator.Div(8d, 0d)));
            Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-8d, 0d)));
            Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
        });
    }

    [TearDown]
    public void TearDown()
    {
        Console.Out.WriteLineAsync("TearDown after test metod");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.Out.WriteLineAsync("OneTimeTearDown finishes");
    }
}