using System.ComponentModel.DataAnnotations;
using Api.Entities;

namespace Api.Dtos;

public record class CreateVisitDto(
    [Required] Subject SubjectID,
    [Required][StringLength(50)] string VisitType,
    [Required] DateTime ScheduledDate,
    DateTime? ActualDate,
    string Notes
);
