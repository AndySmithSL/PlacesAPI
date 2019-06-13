using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ItemView
{
    public class PlaceGroupItemView : PlaceGroupView
    {
        public ICollection<PlaceListView> Places => GetViewList<PlaceListView, Place>(ViewObject.Places.OrderBy(x => x.Name));
    }
}
