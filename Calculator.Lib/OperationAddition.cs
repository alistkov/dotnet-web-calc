namespace Calculator.Lib;

public class OperationAddition : IOperation
{
    public double Execute(double first, double second)
    {
        return first + second;
    }
}