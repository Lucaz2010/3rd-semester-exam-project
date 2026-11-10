namespace Service;

using Infrastructure.Data;
using Infrastructure.Entities;
using DTOs;


public class UserService (AppDbConnection db)
{
    
    public List<UserDto> GetUsers()
    {
        throw new NotImplementedException();
    }

    public UserDto CreateUser(CreateUserRequestDto dto, string currentUserId)
    {
        throw new NotImplementedException();
    }
}