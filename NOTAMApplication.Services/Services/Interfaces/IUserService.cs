namespace NOTAMApplication.Services.Services.Interfaces;

public interface IUserService
{
    Task<Result> RegisterUser(RegisterModelRequest model);
    Task<Result> Login(LoginModelRequest model);
}
