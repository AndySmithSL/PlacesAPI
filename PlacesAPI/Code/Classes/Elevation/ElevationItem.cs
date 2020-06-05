using Newtonsoft.Json;

namespace PlacesAPI.Code.Classes.Elevation
{
    public class ElevationItem
    {
        [JsonProperty(PropertyName = "elevation")]
        public double Elevation { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "resolution")]
        public double Resolution { get; set; }
    }
}
