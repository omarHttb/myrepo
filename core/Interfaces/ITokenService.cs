using core.Entites.Identity;

namespace core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}