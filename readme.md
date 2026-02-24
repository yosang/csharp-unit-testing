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
- `[SetUp]` - Setup Attribute allows a method to run first before other the [Test] methods.
- `[Test]` - Flags a method as testable code, this method will likely have `Assert` calls.
- `[TestCase(a, b)]` - Used to create parameterized tests, allowing a single method to run with multiple set of inputs.