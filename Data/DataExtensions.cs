using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public static class DataExtensions
{
  public static async Task MigrateDbAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<ApiContext>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    await dbContext.Database.MigrateAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
  }
}
