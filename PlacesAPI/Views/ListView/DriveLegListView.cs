using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class DriveLegListView : DriveLegView
    {
        public new string Drive => ViewObject.Drive.Name;
        public new string Origin => ViewObject.Origin.Name;
        public new string Destination => ViewObject.Destination.Name;
    }
}
