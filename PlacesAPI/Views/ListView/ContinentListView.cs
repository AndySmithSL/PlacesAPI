using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class ContinentListView : ContinentView
    {
        public string Parent => ViewObject.ParentId.HasValue ? ViewObject.Parent.Name : "--";

        public int Children => ViewObject.Children.Count;

        public int Territories => ViewObject.Territories.Count;

        public string ListValue => Children.ToString() + "/" + TotalTerritories.ToString();

        public int SubContinentTerritories => ViewObject.SubContinentTerritories.Count;

        public int TotalTerritories => Territories > 0 ? Territories : SubContinentTerritories;
    }
}
