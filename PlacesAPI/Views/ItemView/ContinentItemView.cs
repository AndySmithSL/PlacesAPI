using PlacesAPI.Models;
using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ItemView
{
    public class ContinentItemView : ContinentView
    {
        public new ContinentItemView Parent => GetView<ContinentItemView, Continent>(ViewObject.Parent);
    }
}
