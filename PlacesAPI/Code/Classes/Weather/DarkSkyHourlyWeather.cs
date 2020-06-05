using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlacesAPI.Code.Classes.Weather
{
    public class DarkSkyHourlyWeather
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<DarkSkyWeatherItem> Data { get; set; }
    }
}
