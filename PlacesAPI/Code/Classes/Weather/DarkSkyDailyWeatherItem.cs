using Newtonsoft.Json;

namespace PlacesAPI.Code.Classes.Weather
{
    public class DarkSkyDailyWeatherItem
    {
        [JsonProperty(PropertyName = "time")]
        public int Time { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "sunriseTime")]
        public int SunriseTime { get; set; }

        [JsonProperty(PropertyName = "sunsetTime")]
        public int SunsetTime { get; set; }

        [JsonProperty(PropertyName = "precipProbability")]
        public double PrecipProbability { get; set; }

        [JsonProperty(PropertyName = "temperatureHigh")]
        public double TemperatureHigh { get; set; }

        [JsonProperty(PropertyName = "temperatureHighTime")]
        public int TemperatureHighTime { get; set; }

        [JsonProperty(PropertyName = "temperatureLow")]
        public double TemperatureLow { get; set; }

        [JsonProperty(PropertyName = "temperatureLowTime")]
        public int TemperatureLowTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureHigh")]
        public double ApparentTemperatureHigh { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureHighTime")]
        public int ApparentTemperatureHighTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureLow")]
        public double ApparentTemperatureLow { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureLowTime")]
        public int ApparentTemperatureLowTime { get; set; }

        [JsonProperty(PropertyName = "windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty(PropertyName = "windBearing")]
        public double WindBearing { get; set; }

        [JsonProperty(PropertyName = "temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonProperty(PropertyName = "temperatureMinTime")]
        public int TemperatureMinTime { get; set; }

        [JsonProperty(PropertyName = "temperatureMax")]
        public double TemperatureMax { get; set; }

        [JsonProperty(PropertyName = "temperatureMaxTime")]
        public int TemperatureMaxTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMinTime")]
        public int ApparentTemperatureMinTime { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }

        [JsonProperty(PropertyName = "apparentTemperatureMaxTime")]
        public int ApparentTemperatureMaxTime { get; set; }

    }
}
      