using LlmExtractionApi.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from configuration (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the DbContext with SQL Server provider
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// Add controllers
builder.Services.AddControllers();

// Register the endpoints API explorer
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation and enable annotations
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

var app = builder.Build();

// Enable Swagger middleware before any other middleware
app.UseSwagger();
app.UseSwaggerUI();

// Display detailed error information in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Map controller endpoints
app.MapControllers();

// Run the application
app.Run();
