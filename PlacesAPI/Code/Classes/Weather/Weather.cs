namespace PlacesAPI.Code.Classes.Weather
{
    public class Weather
    {
        public Weather(DarkSkyWeather darkSkyWeather)
        {
            DarkSky = darkSkyWeather;
        }

        private DarkSkyWeather DarkSky { get; set; }

        #region Json Output

        public double Latitude => DarkSky.Latitude;
        public double Longitude => DarkSky.Longitude;
        public string Timezone => DarkSky.Timezone;
        public double Offset => DarkSky.Offset;

        public WeatherItem Current => new WeatherItem(DarkSky.Current, Offset);
        public HourlyWeather Hourly => new HourlyWeather(DarkSky.Hourly, Offset);
        public DailyWeather Daily => new DailyWeather(DarkSky.Daily, Offset);

        #endregion Json Output
    }
}
