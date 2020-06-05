namespace PlacesAPI.Code.Classes.Weather
{
    public class DailyWeatherItem
    {
        public DailyWeatherItem(DarkSkyDailyWeatherItem darkSky, double offset)
        {
            DarkSky = darkSky;
            Offset = offset;
        }

        private DarkSkyDailyWeatherItem DarkSky { get; set; }
        private double Offset { get; set; }

        #region Json Output

        public WeatherTime Time => new WeatherTime(DarkSky.Time, Offset);
        public string Summary => DarkSky.Summary;
        public string Icon => DarkSky.Icon;
        public WeatherTime SunriseTime => new WeatherTime(DarkSky.SunriseTime, Offset);
        public WeatherTime SunsetTime => new WeatherTime(DarkSky.SunsetTime, Offset);
        public double PrecipProbability => DarkSky.PrecipProbability;

        public WeatherTemperature TemperatureHigh => new WeatherTemperature(DarkSky.TemperatureHigh);
        public WeatherTime TemperatureHighTime => new WeatherTime(DarkSky.TemperatureHighTime, Offset);

        public WeatherTemperature TemperatureLow => new WeatherTemperature(DarkSky.TemperatureLow);
        public WeatherTime TemperatureLowTime => new WeatherTime(DarkSky.TemperatureLowTime, Offset);

        public WeatherTemperature ApparentTemperatureHigh => new WeatherTemperature(DarkSky.ApparentTemperatureHigh);
        public WeatherTime ApparentTemperatureHighTime => new WeatherTime(DarkSky.ApparentTemperatureHighTime, Offset);

        public WeatherTemperature ApparentTemperatureLow => new WeatherTemperature(DarkSky.ApparentTemperatureLow);
        public WeatherTime ApparentTemperatureLowTime => new WeatherTime(DarkSky.ApparentTemperatureLowTime, Offset);

        public double WindSpeed => DarkSky.WindSpeed;
        public double WindBearing => DarkSky.WindBearing;

        public WeatherTemperature TemperatureMin => new WeatherTemperature(DarkSky.TemperatureMin);
        public WeatherTime TemperatureMinTime => new WeatherTime(DarkSky.TemperatureMinTime, Offset);

        public WeatherTemperature TemperatureMax => new WeatherTemperature(DarkSky.TemperatureMax);
        public WeatherTime TemperatureMaxTime => new WeatherTime(DarkSky.TemperatureMaxTime, Offset);

        public WeatherTemperature ApparentTemperatureMin => new WeatherTemperature(DarkSky.ApparentTemperatureMin);
        public WeatherTime ApparentTemperatureMinTime => new WeatherTime(DarkSky.ApparentTemperatureMinTime, Offset);

        public WeatherTemperature ApparentTemperatureMax => new WeatherTemperature(DarkSky.ApparentTemperatureMax);
        public WeatherTime ApparentTemperatureMaxTime => new WeatherTime(DarkSky.ApparentTemperatureMaxTime, Offset);

        #endregion Json Output
    }
}
