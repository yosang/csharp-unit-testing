# Project
This is a simple practice-project that showcases Unit Testing in C# with two frameworks, `NUnit` and `XUnit`.

We are configuring this project with a dotnet `sln` template.
- It acts as a container or organizer for one or more related .NET projects.'
    - To create a sln project we use the command `dotnet new sln -n MyApp`.
    - To add projects we use the command `dotnet sln add <xxxx.csproj>`.
    - To list projects wen use the command `dotnet sln list`

## Sequence of commands for setup:
```bash
# Create Solution
dotnet new sln -n MyUnitTestApp # Creates a solution for this project

# C# Class Library
dotnet new classlib -n Main -o src/

# NUnit
dotnet new nunit -n Tests.NUnit -o tests/NUnit # Creates the project for NUnit tests
cd tests/NUnit # We have to be inside the folder when adding a reference
dotnet add reference ../../src/Main.csproj # Adds the src/Main project reference

# NUnit
dotnet new xunit -n Tests.xUnit -o tests/xUnit # Creates the project for xUnit tests
cd tests/xUnit
dotnet add reference ../../src/Main.csproj # Adds the src/Main project reference

# Add everything to Solution
dotnet sln add src/Main.csproj 
dotnet sln add tests/NUnit/Tests.NUnit.csproj 
dotnet sln add tests/xUnit/Tests.xUnit.csproj 

# To see whats currently on the solution
dotnet sln list

# To remove one from the solution while testing another simply swap them from the solution list and so on...
dotnet sln remove tests/NUnit/Tests.NUnit.csproj 
dotnet sln add tests/xUnit/Tests.xUnit.csproj 
```

Use `dotnet test` to test either framework.

# NUnit syntax
- `[SetUp]` - Setup Attribute allows a method to run first before the other `[Test]` methods.
    ```c#
    [SetUp]
    public void Before() => _calc = new Calculator();
    ```
- `[Test]` - Flags a method as testable code, this method will likely have `Assert` calls.
    ```c#
    [Test]
    public void Add_ReturnsSum()
    {
        // Arrange
        int param1 = 3;
        int param2 = 7;
        int expected = 10;

        // Act
        int result = _calc.Add(param1, param2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    ```
- `[TestCase(a, b)]` - Used to create parameterized tests, allowing a single method to run with multiple set of inputs.
    ```c#
    [TestCase(2, true)]
    [TestCase(7, false)]
    [TestCase(-4, true)]
    public void IsEven_Works(int number, bool expected)
    {
        Assert.That(_calc.IsEven(number), Is.EqualTo(expected));
    }
    ```

# XUnit syntax
- `[Fact]` - A `[Fact]` attribute is used to declare a parameterless method as an individual test to be executed by the test runner.
    ```c#
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
    ```
- `[Theory]` - A `[Theory]` attribute is similar to a `[Fact]` but with the difference that it can accept parameters
- `[InlineData]` - Used with `[Theory]` and allows the test runnet to run this method multiple times with different sets of input parameters.
    ```c#
    [Theory]
    [InlineData(2, true)]
    [InlineData(7, false)]
    [InlineData(-4, true)]
    public void IsEven_Works(int num, bool expected)
    {
        Assert.Equal(expected, Calc.IsEven(num));
    }
    ```
# Summary

# Usage
1. Clone the repository with `git clone https://github.com/yosang/csharp-unit-testing`
2. To switch between testing frameworks, you have to `remove` and `add` each individual to the project solution.
    - Use `dotnet sln list` to list the current project.
    - For example, to test the xUnit framework use:
        - `dotnet sln remove tests/xUnit/Tests.NUnit.csproj` to remove NUnit from the solution.
        - `dotnet sln add tests/xUnit/Tests.xUnit.csproj` to add xUnit from the solution.
3. Test the application with `dotnet test`.

# Author
[Yosmel Chiang](https://github.com/yosang)