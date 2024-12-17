using Calculator.Lib.Interfaces;

namespace Calculator.Lib.Operations;

public class OperationDivision : IOperation
{
    public double Execute(double first, double second)
    {
        if (second == 0)
            throw new Exception("You can't divide by zero");

        return first / second;
    }
}