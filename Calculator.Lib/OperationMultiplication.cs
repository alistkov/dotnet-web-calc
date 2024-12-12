namespace Calculator.Lib;

public class OperationMultiplication : Operation
{
    public override double Execute(double first, double second)
    {
        return first * second;
    }
}