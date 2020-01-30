using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.ItemView
{
    public class RouteItemView : RouteView
    {
        public new ICollection<RouteLegListView> RouteLegs => GetViewList<RouteLegListView, RouteLeg>(ViewObject.RouteLegs.OrderBy(x => x.Number));

        public PlaceListView Origin => GetView<PlaceListView, Place>(ViewObject.Origin);

        public PlaceListView Destination => GetView<PlaceListView, Place>(ViewObject.Destination);

        public ICollection<PlaceListView> Waypoints => GetViewList<PlaceListView, Place>(ViewObject.Waypoints);
    }
}
