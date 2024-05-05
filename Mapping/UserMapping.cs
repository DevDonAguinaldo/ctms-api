using Api.Dtos;
using Api.Entities;

namespace Api.Mapping;

public static class UserMapping
{
  public static User ToEntity(this CreateUserDto user)
  {
    return new User()
    {
      Username = user.Username,
      Email = user.Email,
      PasswordHash = user.Password,
      Role = user.Role,
      FirstName = user.FirstName,
      LastName = user.LastName,
      ContactNumber = user.ContactNumber,
    };
  }

  public static UserDto ToDto(this User user)
  {
    return new(
      user.UserID,
      user.Username,
      user.Email,
      user.PasswordHash,
      user.Role,
      user.FirstName,
      user.LastName,
      user.ContactNumber
    );
  }

  public static User ToEntity(this UpdateUserDto user, int id)
  {
    return new User()
    {
      UserID = id,
      Username = user.Username,
      Email = user.Email,
      PasswordHash = user.Password,
      Role = user.Role,
      FirstName = user.FirstName,
      LastName = user.LastName,
      ContactNumber = user.ContactNumber,
    };
  }
}
