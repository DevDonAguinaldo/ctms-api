namespace Api.Dtos;

public record class UserDto(
    int UserID,
    string Username,
    string Email,
    string Password,
    string Role,
    string FirstName,
    string LastName,
    string ContactNumber
);
