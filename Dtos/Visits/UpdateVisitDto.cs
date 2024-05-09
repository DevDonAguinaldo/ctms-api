using System.ComponentModel.DataAnnotations;
using Api.Entities;

namespace Api.Dtos;

public record class UpdateVisitDto(
    [StringLength(50)] string VisitType,
    DateTime ScheduledDate,
    DateTime ActualDate,
    string Notes,
    Subject SubjectID
);
