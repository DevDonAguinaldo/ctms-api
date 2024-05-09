using Api.Dtos;
using Api.Entities;

namespace Api.Mapping;

public static class VisitMapping
{
  public static VisitDto ToDto(this Visit visit)
  {
    return new VisitDto(
        visit.VisitID,
        visit.VisitType,
        visit.ScheduledDate,
        visit.ActualDate,
        visit.Notes,
        visit.Subject
    );
  }

  public static Visit ToEntity(this CreateVisitDto dto)
  {
    return new Visit()
    {
      VisitType = dto.VisitType,
      ScheduledDate = dto.ScheduledDate,
      ActualDate = dto.ActualDate,
      Notes = dto.Notes,
      Subject = dto.SubjectID
    };
  }

  public static Visit ToEntity(this UpdateVisitDto visit, int id)
  {
    return new Visit()
    {
      VisitID = id,
      VisitType = visit.VisitType,
      ScheduledDate = visit.ScheduledDate,
      ActualDate = visit.ActualDate,
      Notes = visit.Notes,
      Subject = visit.SubjectID
    };
  }
}
