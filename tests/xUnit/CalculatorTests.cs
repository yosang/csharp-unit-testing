using Main;

public class CalculatorTests
{
    // With xUnit we dont need a [Setup], so we can use an automatic property
    private Calculator Calc { get; } = new(); // Readonly, to prevent any accidental reassignment

    // A [Fact] attribute is used to declare a parameterless method as an individual test To be executed by the test runner.
    [Fact]
    public void Add_ReturnsSum()
    {
        // Arrange
        int param1 = 3;
        int param2 = 7;
        int expected = 10;

        // Act
        int result = Calc.Add(param1, param2);

        // Assert
        Assert.Equal(expected, result);
    }


    [Fact]
    public void Divide_ByZero_Throws()
    {
        // Arrange
        int param1 = 10;
        int param2 = 0;

        // Act + Assert
        Assert.Throws<DivideByZeroException>(() => Calc.Divide(param1, param2));
    }

    // A [Theory] attribute is similar to a [Fact] but with the difference that it can accept parameters
    // And run multiple times with different sets of data provided by the [InlineData] attribue.
    [Theory]
    [InlineData(2, true)]
    [InlineData(7, false)]
    [InlineData(-4, true)]
    public void IsEven_Works(int num, bool expected)
    {
        Assert.Equal(expected, Calc.IsEven(num));
    }
}