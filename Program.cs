using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection");
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapUsersEndpoints();

await app.MigrateDbAsync();

app.Run();
