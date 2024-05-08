using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
  public DbSet<User> Users => Set<User>();
  public DbSet<Trial> Trials => Set<Trial>();
  public DbSet<Subject> Subjects => Set<Subject>();
}
