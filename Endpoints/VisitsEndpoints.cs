using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Mapping;

namespace Api.Endpoints;
public static class VisitsEndpoints
{
  const string GetVisitEndpointName = "GetVisit";

  public static RouteGroupBuilder MapVisitsEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("visits").WithParameterValidation();

    // Get all visits
    group.MapGet("/", async (ApiContext dbContext) =>
        await dbContext.Visits
            .Select(visit => visit.ToDto())
            .AsNoTracking()
            .ToListAsync());

    // Get a single visit by ID
    group.MapGet("/{id}", async (int id, ApiContext dbContext) =>
    {
      Visit? visit = await dbContext.Visits.FindAsync(id);
      return visit is null ? Results.NotFound() : Results.Ok(visit.ToDto());
    }).WithName(GetVisitEndpointName);

    // Create a new visit
    group.MapPost("/", async (CreateVisitDto newVisit, ApiContext dbContext) =>
    {
      Visit visit = newVisit.ToEntity();
      dbContext.Visits.Add(visit);
      await dbContext.SaveChangesAsync();
      return Results.CreatedAtRoute(GetVisitEndpointName, new { id = visit.VisitID }, visit.ToDto());
    });

    // Update an existing visit
    group.MapPut("/{id}", async (int id, UpdateVisitDto updatedVisit, ApiContext dbContext) =>
    {
      var existingVisit = await dbContext.Visits.FindAsync(id);
      if (existingVisit is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingVisit).CurrentValues.SetValues(updatedVisit.ToEntity(id));
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    // Delete a visit
    group.MapDelete("/{id}", async (int id, ApiContext dbContext) =>
    {
      var visit = await dbContext.Visits.FindAsync(id);
      if (visit != null)
      {
        dbContext.Visits.Remove(visit);
        await dbContext.SaveChangesAsync();
        return Results.NoContent();
      }
      return Results.NotFound();
    });

    return group;
  }
}
