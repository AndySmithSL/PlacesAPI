using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class TerritoryListView: TerritoryView
    {
        public new string Parent => ParentId.HasValue ? ViewObject.Parent?.Name : "--";
        public new string Continent => ContinentId.HasValue ? ViewObject.Continent?.Name : "--";
        public new string Flag => FlagId.HasValue ? ViewObject.Flag?.Name : "--";
        public string FlagCode => FlagId.HasValue ? ViewObject.Flag?.Code : "--";
        public string FlagImage => FlagId.HasValue ? base.Flag?.Image : "--";
        public new string TerritoryType => TerritoryTypeId.HasValue ? ViewObject.TerritoryType?.Type : "--";
        public new int Places => base.Places.Count;
        public new int Children => ViewObject.Children.Count;
        public new int ChildrenPlaces => ViewObject.ChildrenPlaces.Count;
    }
}
