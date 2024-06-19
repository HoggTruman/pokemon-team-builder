using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Account;

public class LoginDTO
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}