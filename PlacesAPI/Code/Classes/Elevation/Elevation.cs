using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlacesAPI.Code.Classes.Elevation
{
    public class Elevation
    {
        [JsonProperty(PropertyName = "results")]
        public List<ElevationItem> Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
