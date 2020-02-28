using PlacesAPI.Code.Classes;
using PlacesAPI.Views.Base;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.ListView
{
    public class PlaceListView : PlaceView
    {
        public IEnumerable<string> Flags => base.Territories.Select(x => x.Flag != null ? x.Flag.Image : "BLANK.png");
        public new IEnumerable<string> Territories => base.Territories.Select(x => x.Name);

        public string LatitudeDegrees => Latitude.HasValue ? GeoAngle.FromDouble(Latitude.Value).ToString("NS") : "--";
        public string LongitudeDegrees => Longitude.HasValue ? GeoAngle.FromDouble(Longitude.Value).ToString("WE") : "--";

        // Groups
        public int Groups => ViewObject.PlaceGroups.Count;
        public IEnumerable<string> GroupItems => ViewObject.PlaceGroups.Select(x => x.Name);

        // Drives
        public int Drives => ViewObject.Drives.Count;
        public int DriveOriginLegs => ViewObject.DriveOriginLegs.Count;
        public int DriveDestinationLegs => ViewObject.DriveDestinationLegs.Count;

        // Routes
        public int Routes => ViewObject.Routes.Count;
        public int RouteOriginLegs => ViewObject.RouteOriginLegs.Count;
        public int RouteDestinationLegs => ViewObject.RouteDestinationLegs.Count;

    }
}
