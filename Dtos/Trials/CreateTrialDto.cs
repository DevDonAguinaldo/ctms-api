using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record class CreateTrialDto(
    [Required][StringLength(255)] string Title,
    string Description,
    [Required] DateTime StartDate,
    [Required] DateTime EndDate,
    [Required][StringLength(50)] string Status,
    int? PrincipalInvestigatorID,
    decimal? Budget
);
