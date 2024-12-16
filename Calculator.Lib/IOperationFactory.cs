namespace Calculator.Lib;

public interface IOperationFactory
{ 
    IOperation GetOperation(string operation);
}