using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.ItemView
{
    public class ContinentItemView : ContinentView
    {
        public ContinentListView Parent => GetView<ContinentListView, Continent>(ViewObject.Parent);

        public ICollection<ContinentListView> Children => GetViewList<ContinentListView, Continent>(ViewObject.Children.OrderBy(x => x.Name));

        public ICollection<TerritoryListView> Territories => GetViewList<TerritoryListView, Territory>(ViewObject.Territories.OrderBy(x => x.Name));

        public ICollection<TerritoryListView> SubContinentTerritories => GetViewList<TerritoryListView, Territory>(ViewObject.SubContinentTerritories.OrderBy(x => x.Name));

        public ICollection<TerritoryListView> TotalTerritories => Territories.Count > 0 ? Territories : SubContinentTerritories;
    }
}
