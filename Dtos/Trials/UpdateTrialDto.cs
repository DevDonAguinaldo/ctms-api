namespace Api.Dtos;

public record class UpdateTrialDto(
    string Title,
    string Description,
    DateTime? StartDate,
    DateTime? EndDate,
    string Status,
    int? PrincipalInvestigatorID,
    decimal? Budget
);