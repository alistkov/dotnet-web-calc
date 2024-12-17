namespace Calculator.Lib.Interfaces;

public interface IOperationFactory
{ 
    IOperation GetOperation(string operation);
}