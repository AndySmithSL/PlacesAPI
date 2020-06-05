using Newtonsoft.Json;
using System;

namespace PlacesAPI.Code.Classes.Weather
{
    public class DarkSkyWeatherItem
    {
        [JsonProperty(PropertyName = "time")]
        public int Time { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double ApparentTemperature { get; set; }

        [JsonProperty(PropertyName = "windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty(PropertyName = "windBearing")]
        public double WindBearing { get; set; }
    }
}
  