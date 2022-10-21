namespace TestController
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is WeatherForecast forecast &&
                   Date == forecast.Date &&
                   Summary == forecast.Summary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Summary);
        }
    }
}