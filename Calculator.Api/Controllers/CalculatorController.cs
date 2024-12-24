using Calculator.Domain.Entities;
using Calculator.Lib;
using Calculator.Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Api.Controllers;

[ApiController]
[Route("api/calculator")]
public class CalculatorController(IOperationFactory operationFactory) : ControllerBase
{
    /// <summary>
    /// Calculates the result based on two operands and an operation
    /// </summary>
    /// <param name="first">First number</param>
    /// <param name="operation">Operation (add/sub/mult/div)</param>
    /// <param name="second">Second number</param>
    /// <returns>Returns result or bad request if operation is division and second operand is 0</returns>
    /// <response code="200">Returns result of calculation</response>
    /// <response code="400">Returns error when operation is division and second operand is 0</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ReturnEntity> CalculateArgs(
        [FromQuery] double first, [FromQuery] string operation, [FromQuery] double second)
    {
        try
        {
            var operationCls = operationFactory.GetOperation(operation);

            return Ok( new ReturnEntity
            {
                First = first,
                Second = second,
                Operation = operation,
                Result = operationCls.Execute(first, second)
            });
        }
        catch
        {
            return BadRequest();
        }
    }
}