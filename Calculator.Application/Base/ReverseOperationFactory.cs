using Calculator.Application.Interfaces;
using Calculator.Application.Operations;

namespace Calculator.Application.Base;

public class ReverseOperationFactory : IOperationFactory
{
    public IOperation GetOperation(string operation)
    {
        IOperation operationCls = operation switch
        {
            "sub" => new OperationAddition(),
            "add" => new OperationSubtraction(),
            "div" => new OperationMultiplication(),
            "mult" => new OperationDivision(),
            _ => throw new Exception("Unknown operation")
        };
        return operationCls;
    }
}