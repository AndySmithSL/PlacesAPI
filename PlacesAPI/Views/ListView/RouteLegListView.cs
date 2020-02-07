using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class RouteLegListView : RouteLegView
    {
        public string Route => ViewObject.Route.Name;
        
        public string Destination => ViewObject.Destination.Name;

        //TODO:AS
        public string Origin => ViewObject.Origin.Name;
        public double? OriginLat => ViewObject.Origin.Latitude;
        public double? OriginLng => ViewObject.Origin.Longitude;

    }
}
