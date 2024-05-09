using Api.Entities;

namespace Api.Dtos;

public record class VisitDto(
    int VisitID,
    string VisitType,
    DateTime ScheduledDate,
    DateTime? ActualDate,
    string Notes,
    Subject SubjectID
);
