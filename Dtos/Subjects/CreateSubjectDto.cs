using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record class CreateSubjectDto(
    [Required] int TrialID,
    [Required][StringLength(30)] string FirstName,
    [Required][StringLength(30)] string LastName,
    [Required] DateTime DOB,
    [Required][StringLength(10)] string Gender,
    [Required][StringLength(20)] string EnrollmentStatus
);
