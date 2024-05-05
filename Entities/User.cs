namespace Api.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public class User
{
    public int UserID { get; set; }
    
    public required string Username { get; set; }
    
    public required string PasswordHash { get; set; }

    public required string Email { get; set; }
    
    public required string Role { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string ContactNumber { get; set; }
}
