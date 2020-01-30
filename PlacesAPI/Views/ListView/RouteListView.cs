using PlacesAPI.Views.Base;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.ListView
{
    public class RouteListView : RouteView
    {
        public int Legs => ViewObject.RouteLegs.Count();
        public string Origin => ViewObject.Origin?.Name;
        public string Destination => ViewObject.Destination?.Name;
        public IEnumerable<string> Waypoints => ViewObject.Waypoints.Select(x => x.Name);
    }
}
