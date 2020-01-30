using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class RouteLegListView : RouteLegView
    {
        public string Route => ViewObject.Route.Name;
        public string Origin => ViewObject.Origin.Name;
        public string Destination => ViewObject.Destination.Name;
    }
}
