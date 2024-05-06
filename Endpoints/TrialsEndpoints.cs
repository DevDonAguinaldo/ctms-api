using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Mapping;

namespace Api.Endpoints;
public static class TrialsEndpoints
{
  const string GetTrialEndpointName = "GetTrial";

  public static RouteGroupBuilder MapTrialsEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("trials").WithParameterValidation();

    // Get all trials
    group.MapGet("/", async (ApiContext dbContext) =>
        await dbContext.Trials
            .Select(trial => trial.ToDto())
            .AsNoTracking()
            .ToListAsync());

    // Get a single trial by ID
    group.MapGet("/{id}", async (int id, ApiContext dbContext) =>
    {
      Trial? trial = await dbContext.Trials.FindAsync(id);
      return trial is null ? Results.NotFound() : Results.Ok(trial.ToDto());
    }).WithName(GetTrialEndpointName);

    // Create a new trial
    group.MapPost("/", async (CreateTrialDto newTrial, ApiContext dbContext) =>
    {
      Trial trial = newTrial.ToEntity();
      dbContext.Trials.Add(trial);
      await dbContext.SaveChangesAsync();
      return Results.CreatedAtRoute(GetTrialEndpointName, new { id = trial.TrialID }, trial.ToDto());
    });

    // Update an existing trial
    group.MapPut("/{id}", async (int id, UpdateTrialDto updatedTrial, ApiContext dbContext) =>
    {
      var existingTrial = await dbContext.Trials.FindAsync(id);
      if (existingTrial is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingTrial).CurrentValues.SetValues(updatedTrial.ToEntity(id));
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    // Delete a trial
    group.MapDelete("/{id}", async (int id, ApiContext dbContext) =>
    {
      var trial = await dbContext.Trials.FindAsync(id);
      if (trial != null)
      {
        dbContext.Trials.Remove(trial);
        await dbContext.SaveChangesAsync();
        return Results.NoContent();
      }
      return Results.NotFound();
    });

    return group;
  }
}
