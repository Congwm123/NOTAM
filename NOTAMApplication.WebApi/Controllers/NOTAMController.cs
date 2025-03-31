using Microsoft.AspNetCore.Authorization;
using NOTAMApplication.Services.Results;

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

    [Authorize]
    [HttpGet("search/{facility}")]
    public async Task<IActionResult> Get([FromRoute] string facility)
    {
        var result = await _nOTAMServices.GetNOTAMByFacility(facility);
        return result.Match<IActionResult>(
            onSuccess: () => Ok(result),
            onFailure: error => BadRequest(error));
    }
}
