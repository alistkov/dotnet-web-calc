namespace Calculator.Application.Interfaces;

public interface IOperationFactory
{
    IOperation GetOperation(string operation);
}