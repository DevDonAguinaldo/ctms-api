namespace Api.Dtos;

public record class UpdateUserDto(
  string Username,
  string Email,
  string Password,
  string Role,
  string FirstName,
  string LastName,
  string ContactNumber
);