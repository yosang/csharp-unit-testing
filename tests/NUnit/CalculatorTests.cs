using Main;

public class CalculatorTests
{
    private Calculator _calc; // property we will be using for this test

    // [Setup] Attribute allows this method to run first before other the [Test] methods.
    // This is the same as creating a new instance inside each Test codeblock before running the test
    [SetUp]
    public void BeforeEachTest() => _calc = new Calculator();

    // [Test] Attribute defines this method as a method that contains test code
    // It is common to name the method as what we expect it to do.
    [Test]
    public void Add_ReturnsSum()
    {
        // AAA

        // Arrange
        int param1 = 3;
        int param2 = 7;
        int expected = 10;

        // Act
        int result = _calc.Add(param1, param2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_ByZero_Throws()
    {
        // Arrange
        int param1 = 3;
        int param2 = 0;

        // Act + Assert - When using Throws, we must use a callback function
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(param1, param2));
    }

    // Instead of Arranging inside the method
    // We can use TestCase, which allows use provide argumentes to the test method
    // We can provide multiple TestCAse
    [TestCase(2, true)]
    [TestCase(7, false)]
    [TestCase(-4, true)]
    public void IsEven_Works(int number, bool expected)
    {
        Assert.That(_calc.IsEven(number), Is.EqualTo(expected));
    }
}