namespace NOTAMApplication.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NOTAMController : ControllerBase
{
    private readonly ILogger<NOTAMController> _logger;
    private INOTAMServices _nOTAMServices;

    public NOTAMController(ILogger<NOTAMController> logger, INOTAMServices nOTAMServices)
    {
        _logger = logger;
        _nOTAMServices = nOTAMServices;
    }

    [HttpGet("search/{facility}")]
    public async Task<IActionResult> Get([FromRoute] string facility)
    {
        var rs = await _nOTAMServices.GetNOTAMByFacility(facility);
        return Ok(rs);
    }
}
