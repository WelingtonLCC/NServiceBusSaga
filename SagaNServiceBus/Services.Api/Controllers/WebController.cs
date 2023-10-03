namespace Services.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebController : ControllerBase
{
    private readonly IPedidosApplicationServices _applicationServices;
    public WebController(IPedidosApplicationServices applicationServices)
    {
        _applicationServices = applicationServices;
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InsertPrimaryValue insertValue)
    {
        var result = await _applicationServices.Add(insertValue!);

        return Ok(result);
    }
}
