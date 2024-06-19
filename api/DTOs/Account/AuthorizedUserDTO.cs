using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Account;

public class AuthorizedUserDTO
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Token { get; set; }
}