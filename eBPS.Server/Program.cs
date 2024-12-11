using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using System.Data;
using eBPS.Infrastructure.DataAccess;
using eBPS.Server;
using eBPS.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.ServiceRegistration();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// SqlServer Connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add FluentMigrator to the DI container
builder.Services.AddFluentMigrator(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add Swagger services
builder.Services.AddSwaggerConfig(builder.Configuration);

// Add authentication services
builder.Services.AddJwtConfig(builder.Configuration);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

// Run FluentMigrator to apply migrations at startup (optional)
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp(); // Apply all pending migrations
}

app.Run();
