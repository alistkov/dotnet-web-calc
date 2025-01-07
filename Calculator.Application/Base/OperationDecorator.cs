using Calculator.Application.Interfaces;

namespace Calculator.Application.Base;

public class OperationDecorator : IOperationFactory
{
    public IOperationFactory Factory { get; set; } = new OperationFactory();
    
    public IOperation GetOperation(string operation)
    {
        return Factory.GetOperation(operation);
    }
}