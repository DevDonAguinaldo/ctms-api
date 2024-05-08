using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Dtos;
using Api.Mapping;

namespace Api.Endpoints;

public static class SubjectsEndpoints
{
  public static RouteGroupBuilder MapSubjectsEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("subjects");

    group.MapGet("/", async (ApiContext dbContext) =>
        await dbContext.Subjects
            .Select(subject => subject.ToDto())
            .ToListAsync());

    group.MapGet("/{id}", async (int id, ApiContext dbContext) =>
    {
      var subject = await dbContext.Subjects.FindAsync(id);
      return subject == null ? Results.NotFound() : Results.Ok(subject.ToDto());
    });

    group.MapPost("/", async (CreateSubjectDto dto, ApiContext dbContext) =>
    {
      var subject = dto.ToEntity();
      dbContext.Subjects.Add(subject);
      await dbContext.SaveChangesAsync();
      return Results.Created($"/subjects/{subject.SubjectID}", subject.ToDto());
    });

    group.MapPut("/{id}", async (int id, UpdateSubjectDto dto, ApiContext dbContext) =>
    {
      var subject = await dbContext.Subjects.FindAsync(id);
      if (subject == null) return Results.NotFound();
      subject.UpdateEntity(dto);
      await dbContext.SaveChangesAsync();
      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, ApiContext dbContext) =>
    {
      var subject = await dbContext.Subjects.FindAsync(id);
      if (subject == null) return Results.NotFound();
      dbContext.Subjects.Remove(subject);
      await dbContext.SaveChangesAsync();
      return Results.NoContent();
    });

    return group;
  }
}
