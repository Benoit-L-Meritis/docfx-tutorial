using System.ComponentModel;
namespace MinimalApiSample.dtos;

/// <summary>
/// Weather Forecast
/// </summary>
/// <param name="Date">Date</param>
/// <param name="TemperatureC">Temperature in Celsius</param>
/// <param name="Summary">Optionnal summary</param>

public record WeatherForecast(
    [Description("Date")]
    DateOnly Date,
    [Description("Temperature in Celsius")]
    int TemperatureC,
    [Description("Optionnal summary")]
    string? Summary
)
{
    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    [Description("Temperature in Fahrenheit")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
