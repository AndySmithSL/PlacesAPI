using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class PlaceListView : PlaceView
    {
        public int Territories => ViewObject.Territories.Count;

        public int PlaceGroups => ViewObject.PlaceGroups.Count;

        public int Drives => ViewObject.Drives.Count;

        public IEnumerable<string> Flags => ViewObject.Territories.Select(x => x.Flag != null ? x.Flag.Code : "BLANK.png");

    }
}
