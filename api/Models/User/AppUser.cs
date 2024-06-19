using Microsoft.AspNetCore.Identity;

namespace api.Models.User;

public class AppUser : IdentityUser
{
    public List<Team> Teams { get; } = [];
}