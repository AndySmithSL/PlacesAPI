using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class ContinentListView : ContinentView
    {
        public new string Parent => ViewObject.Parent?.Name;

        public new int Children => ViewObject.Children.Count;

        public new int Territories => ViewObject.Territories.Count;

        public string ListValue => Children.ToString() + "/" + TotalTerritories.ToString();

        public new int SubContinentTerritories => ViewObject.SubContinentTerritories.Count;

        public int TotalTerritories => Territories > 0 ? Territories : SubContinentTerritories;
    }
}
