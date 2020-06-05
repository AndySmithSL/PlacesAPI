using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Code.Classes.Weather
{
    public class DailyWeather
    {
        public DailyWeather(DarkSkyDailyWeather darkSky, double offset)
        {
            DarkSky = darkSky;
            Offset = offset;
        }

        private DarkSkyDailyWeather DarkSky { get; set; }
        private double Offset { get; set; }

        #region Json Output

        public string Summary => DarkSky.Summary;
        public string Icon => DarkSky.Icon;
        public List<DailyWeatherItem> Data => DarkSky.Data.Select(x => new DailyWeatherItem(x, Offset)).ToList();

        #endregion Json Output
    }
}
