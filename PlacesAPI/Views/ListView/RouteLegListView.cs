using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class RouteLegListView : RouteLegView
    {
        public string Route => ViewObject.Route.Name;
        
        public string Origin => ViewObject.Origin.Name;
        public double? OriginLat => ViewObject.Origin.Latitude;
        public double? OriginLng => ViewObject.Origin.Longitude;

        public string Destination => ViewObject.Destination.Name;
        public double? DestinationLat => ViewObject.Destination.Latitude;
        public double? DestinationLng => ViewObject.Destination.Longitude;
    }
}
