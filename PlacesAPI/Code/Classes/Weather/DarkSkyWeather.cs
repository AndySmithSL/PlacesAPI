using Newtonsoft.Json;

namespace PlacesAPI.Code.Classes.Weather
{
    public class DarkSkyWeather
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "currently")]
        public DarkSkyWeatherItem Current { get; set; }

        [JsonProperty(PropertyName = "hourly")]
        public DarkSkyHourlyWeather Hourly { get; set; }

        [JsonProperty(PropertyName = "daily")]
        public DarkSkyDailyWeather Daily { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public double Offset { get; set; }
    }
}
