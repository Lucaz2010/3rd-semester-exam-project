using Security.Services.Security;
using Service.Security.Authorization;
using Infrastructure.Data;
using Service.DTOs;

namespace Service;


public class UserService (AppDbConnection db,IPasswordHasher passwordHasher,
IAuthorizationService authorizationService)
{
    
    public List<UserDto> GetUsers()
    {
        throw new NotImplementedException();
    }

    public UserDto CreateUser(CreateUserRequestDto dto, string currentUserId)
    {
        throw new NotImplementedException();
    }


    public LoginResponseDto Login(LoginRequestDto dto)
    {
        var user = db.Users
            .FirstOrDefault(u =>
                u.Username == dto.Username);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }
        
        bool passwordIsValid = passwordHasher.VerifyPassword(
            dto.Password,
            user.PasswordHash
            
        );

        if (!passwordIsValid)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        return new LoginResponseDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Role = user.Role,
            Token = authorizationService.GenerateToken(user)
        };
        
    }
}