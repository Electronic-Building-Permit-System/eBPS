using Microsoft.Data.SqlClient;
using System.Data;
using eBPS.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
// Retrieve the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register services
builder.Services.ServiceRegistration(connectionString);

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
    new SqlConnection(connectionString));


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

app.Run();
