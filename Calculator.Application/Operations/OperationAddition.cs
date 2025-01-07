using Calculator.Application.Interfaces;

namespace Calculator.Application.Operations;

public class OperationAddition : IOperation
{
    public double Execute(double first, double second)
    {
        return first + second;
    }
}