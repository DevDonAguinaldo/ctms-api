namespace Api.Dtos;

public record class TrialDto(
    int TrialID,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    int? PrincipalInvestigatorID,
    decimal? Budget
);