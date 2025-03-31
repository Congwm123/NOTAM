namespace NOTAMApplication.Services.Services.Implementations;

public class UserService : IUserService
{
    private readonly NOTAMDbContext _context;
    private readonly IConfiguration _configuration;

    public UserService(NOTAMDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<Result> Login(LoginModelRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == model.Username);
        if (user == null || HashPassword(model.Password) != user.PasswordHash)
        {
            return Result.Failure(UserErrors.InvalidCredentials);
        }

        var token = GenerateJwtToken(user);
        return Result.Success(token);
    }

    public async Task<Result> RegisterUser(RegisterModelRequest model)
    {
        if (_context.Users.Any(u => u.Username == model.Username))
        {
            return Result.Failure(UserErrors.AlreadyExist(model.Username));
        }

        var user = new User
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = HashPassword(model.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Result.Success(user.Username);
    }

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
