using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class TerritoryListView: TerritoryView
    {
        public new string Continent => ContinentId.HasValue ? ViewObject.Continent.Name : "--";
        public new string Parent => ParentId.HasValue ? ViewObject.Parent.Name : "--";
        public new string Flag => FlagId.HasValue ? ViewObject.Flag.Name : "--";
        public new string TerritoryType => TerritoryTypeId.HasValue ? ViewObject.TerritoryType.Type : "--";
        public string FlagCode => FlagId.HasValue ? ViewObject.Flag.Code : "--";
        public string FlagImage => FlagId.HasValue ? base.Flag.Image : "--";
        public int Places => ViewObject.Places.Count;
        public int Children => ViewObject.Children.Count;
    }
}
