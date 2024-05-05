using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record class CreateUserDto(
  [Required][StringLength(25)] string Username,
  [Required][StringLength(50)] string Email,
  [Required][StringLength(30)] string Password,
  string Role,
  [Required][StringLength(30)] string FirstName,
  [Required][StringLength(30)] string LastName,
  string ContactNumber
);