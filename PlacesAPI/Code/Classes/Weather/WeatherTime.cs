using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Code.Classes.Weather
{
    public class WeatherTime
    {
        public WeatherTime(int ticks, double offset)
        {
            Ticks = ticks;
            Offset = offset;
        }

        public int Ticks { get; set; }
        public double Offset { get; set; }

        public DateTime UtcTime => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Ticks).ToLocalTime();
        public DateTime LocalTime => UtcTime.ToLocalTime();
        public DateTime PlaceTime => UtcTime.AddHours(Offset);
        public string DayOfWeek => PlaceTime.DayOfWeek.ToString().ToUpper();
        public string TimeLabel => PlaceTime.ToString("HH:mm");
    }
}
