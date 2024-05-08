using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record class UpdateSubjectDto(
    int? TrialID,
    [StringLength(30)] string FirstName,
    [StringLength(30)] string LastName,
    DateTime? DOB,
    [StringLength(10)] string Gender,
    [StringLength(20)] string EnrollmentStatus
);
