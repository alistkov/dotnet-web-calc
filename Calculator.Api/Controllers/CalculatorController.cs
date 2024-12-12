using Calculator.Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Api.Controllers;

[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    [HttpGet]
    public string CalculateArgs(
        [FromQuery] double first, [FromQuery] string operation, [FromQuery] double second)
    {
        Operation operationCls = operation switch
        {
            "add" => new OperationAddition(),
            "sub" => new OperationSubtraction(),
            "mult" => new OperationMultiplication(),
            "div" => new OperationDivision(),
            _ => throw new Exception("Unknown operation")
        };

        var result = operationCls.Execute(first, second);

        var resultJson = new
        {
            first,
            operation,
            second,
            result
        };

        return JsonConvert.SerializeObject(resultJson);
    }
}