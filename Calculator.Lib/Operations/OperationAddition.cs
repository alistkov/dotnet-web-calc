using Calculator.Lib.Interfaces;

namespace Calculator.Lib.Operations;

public class OperationAddition : IOperation
{
    public double Execute(double first, double second)
    {
        return first + second;
    }
}