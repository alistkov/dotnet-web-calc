namespace Calculator.Lib;

public class OperationSubtraction : IOperation
{
    public double Execute(double first, double second)
    {
        return first - second;
    }
}