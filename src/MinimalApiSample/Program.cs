using MinimalApiSample.dtos;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Force v2.0 for DocFX
// builder.Services.AddOpenApi("openApiDefinition", options =>
// {
//     options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
// });
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hello, World!")
    .WithName("Hello")
    .WithDisplayName("Hello")
    .WithTags("Greetings");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast/{number}", (
    [System.ComponentModel.Description("Numbre of data to generate, default = 5")]
    int number = 5
) =>
{   
    var forecast = Enumerable.Range(1, number).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithSummary("Get Weather Forecast")
.WithDescription("Generate random data for weather forecast");

app.Run();
