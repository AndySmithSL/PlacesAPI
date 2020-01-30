using PlacesAPI.Models;
using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ItemView
{
    public class RouteLegItemView: RouteLegView
    {
        public RouteView Route => GetView<RouteView, Route>(ViewObject.Route);
        public PlaceView Origin => GetView<PlaceView, Place>(ViewObject.Origin);
        public PlaceView Destination => GetView<PlaceView, Place>(ViewObject.Destination);
    }
}
