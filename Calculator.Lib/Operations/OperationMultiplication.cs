using Calculator.Lib.Interfaces;

namespace Calculator.Lib.Operations;

public class OperationMultiplication : IOperation
{
    public double Execute(double first, double second)
    {
        return first * second;
    }
}