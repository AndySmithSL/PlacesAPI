using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class DriveListView : DriveView
    {
        public int Legs => ViewObject.DriveLegs.Count();

        public string Origin => ViewObject.Origin?.Name;

        public string Destination => ViewObject.Destination?.Name;

        public IEnumerable<string> Waypoints => ViewObject.Waypoints.Select(x => x.Name);
    }
}
