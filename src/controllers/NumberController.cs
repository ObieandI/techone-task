using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ConvertController : ControllerBase
{
    [HttpPost]
    public IActionResult Convert([FromBody] ConvertRequest request)
    {
        try
        {
            var converter = new NumberToWordsConverter();
            string result = converter.Convert(request.Number);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class ConvertRequest
{
    public string Number { get; set; }
}
