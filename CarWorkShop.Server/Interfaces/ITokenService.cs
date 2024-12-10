using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
