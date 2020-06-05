namespace PlacesAPI.Code.Classes.Weather
{
    public class WeatherTemperature
    {
        public WeatherTemperature(double fahrenheit)
        {
            Fahrenheit = fahrenheit;
        }

        public double Fahrenheit { get; set; }
        public double Celsius => (Fahrenheit - 32) * 5 / 9;
    }
}
