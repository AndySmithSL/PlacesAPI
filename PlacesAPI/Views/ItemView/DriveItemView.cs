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
    }
}
