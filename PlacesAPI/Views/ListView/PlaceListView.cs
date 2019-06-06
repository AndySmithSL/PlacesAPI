using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class PlaceListView : PlaceView
    {
        //public new int Territories => base.Territories.Count;

        //public new int Groups => base.Groups.Count;

        //public int Drives => ViewObject.Drives.Count;

        public IEnumerable<string> Flags => base.Territories.Select(x => x.Flag != null ? x.Flag.Image : "BLANK.png");
    }
}
