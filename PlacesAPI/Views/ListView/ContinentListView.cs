using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class ContinentListView : ContinentView
    {
        public string Parent => ViewObject.ParentId.HasValue ? ViewObject.Parent?.Name : "--";
        public int Children => ViewObject.Children.Count;
        public string ListValue => Children.ToString() + "/" + TotalTerritories.ToString();
        public int TotalTerritories => ViewObject.Territories.Count > 0 ? ViewObject.Territories.Count : ViewObject.SubContinentTerritories.Count;
    }
}
