using Calculator.Application.Interfaces;
using Calculator.Application.Operations;

namespace Calculator.Application.Base;

public class OperationFactory : IOperationFactory
{
    public IOperation GetOperation(string operation)
    {
        IOperation operationCls = operation switch
        {
            "add" => new OperationAddition(),
            "sub" => new OperationSubtraction(),
            "mult" => new OperationMultiplication(),
            "div" => new OperationDivision(),
            _ => throw new Exception("Unknown operation")
        };
        return operationCls;
    }
}