using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection");
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddCors(options =>
{
  options.AddPolicy("ctms", policyBuilder =>
  {
    policyBuilder.WithOrigins("http://localhost:5173");
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowCredentials();
  });
});
builder.Services.AddControllers();

var app = builder.Build();

app.MapUsersEndpoints();
app.MapTrialsEndpoints();
app.UseCors("ctms");
app.MapControllers();
await app.MigrateDbAsync();
app.Run();
