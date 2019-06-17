using PlacesAPI.Code.Classes;
using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class PlaceListView : PlaceView
    {
        public IEnumerable<string> Flags => base.Territories.Select(x => x.Flag != null ? x.Flag.Image : "BLANK.png");

        public new IEnumerable<string> Territories => base.Territories.Select(x => x.Name);

        public string LatitudeDegrees => Latitude.HasValue ? GeoAngle.FromDouble(Latitude.Value).ToString("NS") : "--";

        public string LongitudeDegrees => Longitude.HasValue ? GeoAngle.FromDouble(Longitude.Value).ToString("WE") : "--";






    }
}
