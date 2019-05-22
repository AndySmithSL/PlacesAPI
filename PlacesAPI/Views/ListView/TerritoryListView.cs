using PlacesAPI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ListView
{
    public class TerritoryListView: TerritoryView
    {
        public string Continent => ContinentId.HasValue ? ViewObject.Continent.Name : "--";

        public string Parent => ParentId.HasValue ? ViewObject.Parent.Name : "--";

    }
}
