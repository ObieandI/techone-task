using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/convert")]
public class ConvertController : ControllerBase
{
    private readonly NumberToWordsConverter _converter;

    public ConvertController(NumberToWordsConverter converter)
    {
        _converter = converter;
    }

    [HttpPost]
    public IActionResult Convert([FromBody] ConvertRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Number))
            return BadRequest(new { error = "Please provide a number." });

        if (!decimal.TryParse(request.Number, out var number))
            return BadRequest(new { error = "Please enter a valid number." });

        var result = _converter.Convert(request.Number);
        if (string.IsNullOrWhiteSpace(result))
            return BadRequest(new { error = "Invalid number." });

        return Ok(new { result });
    }
}


public record ConvertRequest([Required] string Number);
