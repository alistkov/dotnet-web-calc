namespace Calculator.Lib;

public class OperationAddition : Operation
{
    public override double Execute(double first, double second)
    {
        return first + second;
    }
}