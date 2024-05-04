using Microsoft.OpenApi.Models;
using UPB.BusinessLogic.Managers;
using UPB.BusinessLogic.Managers.Exceptions;
using Serilog;
using UPB.practica2Certi1.Middleware;

var builder = WebApplication.CreateBuilder(args);

string? logFile = builder.Configuration.GetSection("FilePaths").GetSection("Log").Value;
if (logFile == null) 
{
    throw new JSONSectionException();
}

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logFile)
    .CreateLogger();




builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile(
        "appsettings." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json"
    )
    .Build();
    
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<PatientManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = builder.Configuration.GetSection("AppTitle").Value,
    }); 
});

var app = builder.Build();
app.UseExceptionHandlerMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = builder.Configuration.GetSection("BrowseTabTitle").Value;

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
