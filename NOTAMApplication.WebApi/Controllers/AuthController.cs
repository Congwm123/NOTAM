using NOTAMApplication.Services.Models.RequestModels.User;
using NOTAMApplication.Services.Results;

namespace NOTAMApplication.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private IUserService _userService;

    public AuthController(ILogger<AuthController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelRequest model)
    {
        var result = await _userService.RegisterUser(model);

        return result.Match<IActionResult>(
            onSuccess: () => Ok(result),
            onFailure: error => BadRequest(error));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelRequest model)
    {
        var result = await _userService.Login(model);
        return result.Match<IActionResult>(
            onSuccess: () => Ok(result),
            onFailure: error => BadRequest(error));
    }
}
