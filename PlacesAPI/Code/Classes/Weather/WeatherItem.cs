namespace PlacesAPI.Code.Classes.Weather
{
    public class WeatherItem
    {
        public WeatherItem(DarkSkyWeatherItem darkSky, double offset)
        {
            Offset = offset;
            DarkSky = darkSky;
        }

        private double Offset { get; set; }
        private DarkSkyWeatherItem DarkSky { get; set; }

        #region Json Output

        public WeatherTime Time => new WeatherTime(DarkSky.Time, Offset);
        public string Summary => DarkSky.Summary;
        public string Icon => DarkSky.Icon;
        public WeatherTemperature Temperature => new WeatherTemperature(DarkSky.Temperature);
        public WeatherTemperature ApparentTemperature => new WeatherTemperature(DarkSky.ApparentTemperature);
        public double WindSpeed => DarkSky.WindSpeed;
        public double WindBearing => DarkSky.WindBearing;

        #endregion Json Output
    }
}
