
using Infrastructure.Entities;

namespace Service.Security.Authorization;

public interface IAuthorizationService
{
    public string GenerateToken(User user);
}
