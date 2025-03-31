namespace NOTAMApplication.Common.Errors;

public static class UserErrors
{
    public static Error NotFound(Guid id) => new Error("User.NotFound", $"The user with Id '{id}' was not found");
    public static Error AlreadyExist(string userName) => new Error("User.AlreadyExist", $"The user with UserName '{userName}' already exists");
    public static Error InvalidCredentials => new Error("User.InvalidCredentials", "Invalid username or password.");
}
