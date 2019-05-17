using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ListView
{
    public class ContinentListView : ContinentView
    {
        public new string Parent => ViewObject.Parent?.Name;
    }
}
