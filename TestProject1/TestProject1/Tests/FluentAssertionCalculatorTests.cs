using System;
using System.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject1.Tests;

public class CalculatorTests
{
    private Calculator _calculator;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.Out.WriteLineAsync("OneTimeSetup....");
        _calculator = new Calculator();
    }

    [SetUp]
    public void Setup()
    {
        Console.Out.WriteLineAsync("Setup....");
    }

    [Test]
    [Category("SmokeTest")]
    [Property("Severity", 1)]
    public void TestSum()
    {
        Assert.AreEqual(5, _calculator.Sum(1, 4));
    }

    [TestCase(1, 3)]
    [TestCase(6, 9)]
    [TestCase(3, 5)]
    [TestCase(13, 5)]
    public void WhenSumPositiveNumbers_ThenResultIsPositive(int a, int b)
    {
        // Act
        var result = _calculator.Sum(a, b);

        // Assert
        //Assert.Positive(result);

        result.Should().BePositive();
    }

    [TestCase(1, 3, 4)]
    [TestCase(5, 3, 8)]
    [TestCase(12, 3, 15)]
    [TestCase(-1, 3, 2)]
    public void WhenSumTwoNumbers_ThenResultIsSumOfThatTwoNumbers(int a, int b, int expectedSum)
    {
        // Act
        var result = _calculator.Sum(a, b);

        // Assert
        // Assert.AreEqual(expectedSum, result);
        result.Should().Be(expectedSum);
    }

    [TestCaseSource(typeof(CalculatorTests), nameof(NumbersForTest))]
    public void WhenSumPositiveNumbers_ThenResultIsPositive1(Tuple<int, int> numbers)
    {
        // Act
        var result = _calculator.Sum(numbers.Item1, numbers.Item2);

        // Assert
        //Assert.Positive(result);
        result.Should().BePositive();
    }

    public static IEnumerable NumbersForTest()
    {
        yield return new Tuple<int, int>(1, 2);
        yield return new Tuple<int, int>(6, 5);
        yield return new Tuple<int, int>(2, 7);
        yield return new Tuple<int, int>(22, 23);
    }

    [Test]
    [Property("Priority", 2)]
    public void TestDiv()
    {
        Assert.AreEqual(4, _calculator.Div(8, 2));
        Assert.Throws<DivideByZeroException>(
            delegate { _calculator.Div(8, 0); });
        
        Assert.Throws<DivideByZeroException>(
            () => { _calculator.Div(8, 0); });

        TestDelegate divByZero = () => _calculator.Div(8, 0);
        
        Assert.Throws<DivideByZeroException>(divByZero);
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
        Console.Out.WriteLineAsync("TearDown....");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.Out.WriteLineAsync("OneTimeTearDown....");
    }
}