namespace Calculator.Lib;

public class OperationMultiplication : IOperation
{
    public double Execute(double first, double second)
    {
        return first * second;
    }
}