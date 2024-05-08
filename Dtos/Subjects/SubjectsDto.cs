namespace Api.Dtos;

public record class SubjectDto(
    int SubjectID,
    int TrialID,
    string FirstName,
    string LastName,
    DateTime DOB,
    string Gender,
    string EnrollmentStatus
);
