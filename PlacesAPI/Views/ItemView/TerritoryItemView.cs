using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ItemView
{
    public class TerritoryItemView : TerritoryView
    {
        public new TerritoryListView Parent => GetView<TerritoryListView, Territory>(ViewObject.Parent);

        public new ContinentListView Continent => GetView<ContinentListView, Continent>(ViewObject.Continent);

        public TerritoryTypeListView TerritoryType => GetView<TerritoryTypeListView, TerritoryType>(ViewObject.TerritoryType);

        public new FlagListView Flag => GetView<FlagListView, Flag>(ViewObject.Flag);

        public ICollection<PlaceListView> Places => GetViewList<PlaceListView, Place>(ViewObject.Places.OrderBy(x => x.Name));

        public ICollection<TerritoryListView> Children => GetViewList<TerritoryListView, Territory>(ViewObject.Children.OrderBy(x => x.Name));

    }
}
