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

        public new string Flag => FlagId.HasValue ? ViewObject.Flag.Name : "--";

        public string FlagCode => FlagId.HasValue ? ViewObject.Flag.Code : "--";

        public string FlagImage => FlagId.HasValue ? base.Flag.Image : "--";

        public int Places => ViewObject.Places.Count;

        public int Children => ViewObject.Children.Count;

    }
}
