namespace Main;

public class Calculator
{
    public int Add(int a, int b) => a + b;

    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException();
        return a / b;
    }

    public bool IsEven(int n) => n % 2 == 0;
}