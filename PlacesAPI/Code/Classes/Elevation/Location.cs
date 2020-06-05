using Newtonsoft.Json;

namespace PlacesAPI.Code.Classes.Elevation
{
    public class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double Longitude { get; set; }
    }
}
