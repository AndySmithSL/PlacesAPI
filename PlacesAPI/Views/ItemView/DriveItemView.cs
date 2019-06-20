using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ItemView
{
    public class DriveItemView : DriveView
    {
        public new ICollection<DriveLegListView> DriveLegs => GetViewList<DriveLegListView, DriveLeg>(ViewObject.DriveLegs);

        public PlaceListView Origin => GetView<PlaceListView, Place>(ViewObject.Origin);

        public PlaceListView Destination => GetView<PlaceListView, Place>(ViewObject.Destination);

        public ICollection<PlaceListView> Waypoints => GetViewList<PlaceListView, Place>(ViewObject.Waypoints);
    }
}
