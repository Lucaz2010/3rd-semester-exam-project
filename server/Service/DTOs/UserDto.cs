using Facet;
using Infrastructure;
using Infrastructure.Entities;

namespace Service.DTOs;

[Facet(
    sourceType: typeof(User),
    exclude:
    [
        nameof(User.PasswordHash),
    ]
)]  

public partial class UserDto;