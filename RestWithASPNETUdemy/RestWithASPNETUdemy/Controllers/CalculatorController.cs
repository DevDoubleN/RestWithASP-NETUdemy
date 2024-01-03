using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

	public CalculatorController(ILogger<CalculatorController> logger)
	{
        _logger = logger;
    }

    [HttpGet("Get/{operation}/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string operation, string firstNumber, string secondNumber)
    {
        decimal result = 0;

        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            switch (operation)
            {
                case "Sum":
                    result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    break;
                case "Subtraction":
                    result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    break;
                case "Multiplication":
                    result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    break;
                case "Division":
                    result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    break;
            }

            return Ok(result.ToString());
        }
        
        return BadRequest("Invalid input");
    }

    #region Private methods
    private bool IsNumeric(string strNumber)
    {
        double number;
        
        bool isNumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal value;

        if (decimal.TryParse(strNumber, out value))
            return value;

        return 0;
    }
    #endregion
}
