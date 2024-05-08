using Api.Dtos;
using Api.Entities;

namespace Api.Mapping;

public static class SubjectMapping
{
  public static SubjectDto ToDto(this Subject subject)
  {
    return new SubjectDto
    (
      subject.SubjectID,
      subject.TrialID,
      subject.FirstName,
      subject.LastName,
      subject.DOB,
      subject.Gender,
      subject.EnrollmentStatus
    );
  }

  public static Subject ToEntity(this CreateSubjectDto dto)
  {
    return new Subject
    {
      TrialID = dto.TrialID,
      FirstName = dto.FirstName,
      LastName = dto.LastName,
      DOB = dto.DOB,
      Gender = dto.Gender,
      EnrollmentStatus = dto.EnrollmentStatus
    };
  }

  public static void UpdateEntity(this Subject subject, UpdateSubjectDto dto)
  {
    if (dto.FirstName != null) subject.FirstName = dto.FirstName;
    if (dto.LastName != null) subject.LastName = dto.LastName;
    if (dto.DOB.HasValue) subject.DOB = dto.DOB.Value;
    if (dto.Gender != null) subject.Gender = dto.Gender;
    if (dto.EnrollmentStatus != null) subject.EnrollmentStatus = dto.EnrollmentStatus;
  }
}
