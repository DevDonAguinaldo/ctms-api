using Api.Dtos;
using Api.Entities;

namespace Api.Mapping;

public static class TrialMapping
{
  public static Trial ToEntity(this CreateTrialDto trialDto)
  {
    return new Trial()
    {
      Title = trialDto.Title,
      Description = trialDto.Description,
      StartDate = trialDto.StartDate,
      EndDate = trialDto.EndDate,
      Status = trialDto.Status,
      PrincipalInvestigatorID = trialDto.PrincipalInvestigatorID,
      Budget = trialDto.Budget
    };
  }

  public static TrialDto ToDto(this Trial trial)
  {
    return new TrialDto(
      trial.TrialID,
      trial.Title,
      trial.Description,
      trial.StartDate,
      trial.EndDate,
      trial.Status,
      trial.PrincipalInvestigatorID,
      trial.Budget
    );
  }

  public static Trial ToEntity(this UpdateTrialDto trialDto, int trialId)
  {
    return new Trial()
    {
      TrialID = trialId,
      Title = trialDto.Title,
      Description = trialDto.Description,
      StartDate = trialDto.StartDate ?? default,
      EndDate = trialDto.EndDate ?? default,
      Status = trialDto.Status,
      PrincipalInvestigatorID = trialDto.PrincipalInvestigatorID,
      Budget = trialDto.Budget
    };
  }
}
