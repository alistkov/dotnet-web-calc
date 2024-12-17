using Calculator.Lib;
using Calculator.Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Api.Controllers;

[ApiController]
[Route("api/calculator")]
public class CalculatorController(IOperationFactory operationFactory) : ControllerBase
{
    [HttpGet]
    public ActionResult<string> CalculateArgs(
        [FromQuery] double first, [FromQuery] string operation, [FromQuery] double second)
    {
        var operationCls = operationFactory.GetOperation(operation);
        
        var result = operationCls.Execute(first, second);

        var resultJson = new
        {
            first,
            operation,
            second,
            result
        };

        return Ok(resultJson);
    }
}