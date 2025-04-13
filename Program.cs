using LlmExtractionApi.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.MapControllers();
app.Run();
