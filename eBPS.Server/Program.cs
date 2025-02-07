using Microsoft.Data.SqlClient;
using System.Data;
using eBPS.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Set the URL binding directly within the builder
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Retrieve the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register services
builder.Services.ServiceRegistration(connectionString);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Replace '*' with 'http://localhost:4200'
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
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
