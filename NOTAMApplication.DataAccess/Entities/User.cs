using System.ComponentModel.DataAnnotations;

namespace NOTAMApplication.DataAccess.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
