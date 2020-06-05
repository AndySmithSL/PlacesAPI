using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Code.Classes.Weather
{
    public class HourlyWeather
    {
        public HourlyWeather(DarkSkyHourlyWeather darkSky, double offset)
        {
            DarkSky = darkSky;
            Offset = offset;
        }

        private DarkSkyHourlyWeather DarkSky { get; set; }
        private double Offset { get; set; }

        #region Json Output

        public string Summary => DarkSky.Summary;
        public string Icon => DarkSky.Icon;
        public List<WeatherItem> Data => DarkSky.Data.Select(x => new WeatherItem(x, Offset)).ToList();

        #endregion Json Output
    }
}
