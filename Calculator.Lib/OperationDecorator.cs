using Calculator.Lib.Interfaces;

namespace Calculator.Lib;

public class OperationDecorator : IOperationFactory
{
    public IOperationFactory Factory { get; set; } = new OperationFactory();
    
    public IOperation GetOperation(string operation)
    {
        return Factory.GetOperation(operation);
    }
}