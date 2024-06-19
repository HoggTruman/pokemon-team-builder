using api.Models.User;

namespace api.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser appUser);
}