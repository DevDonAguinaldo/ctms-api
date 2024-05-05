using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Mapping;
namespace Api.Endpoints;
public static class UsersEndpoints
{
  const string GetUserEndpointName = "GetUser";

  public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("users").WithParameterValidation();

    group.MapGet("/", async (ApiContext dbContext) =>
      await dbContext.Users
        .Select(user => user.ToDto())
        .AsNoTracking()
        .ToListAsync());

    group.MapGet("/{id}", async (int id, ApiContext dbContext) =>
    {
      User? user = await dbContext.Users.FindAsync(id);

      return user is null ? Results.NotFound() : Results.Ok(user.ToDto());
    }).WithName(GetUserEndpointName);

    group.MapPost("/", async (CreateUserDto newUser, ApiContext dbContext) =>
    {
      User user = newUser.ToEntity();

      dbContext.Users.Add(user);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetUserEndpointName, new { id = user.UserID }, user.ToDto());
    });

    group.MapPut("/{id}", async (int id, UpdateUserDto updatedUser, ApiContext dbContext) =>
    {
      var existingUser = await dbContext.Users.FindAsync(id);

      if (existingUser is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser.ToEntity(id));
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, ApiContext dbContext) =>
    {
      await dbContext.Users
        .Where(user => user.UserID == id)
        .ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
