using PlacesAPI.Models;
using PlacesAPI.Views.Base;

namespace PlacesAPI.Views.ItemView
{
    public class DriveLegItemView : DriveLegView
    {
        public DriveView Drive => GetView<DriveView, Drive>(ViewObject.Drive);
        public PlaceView Origin => GetView<PlaceView, Place>(ViewObject.Origin);
        public PlaceView Destination => GetView<PlaceView, Place>(ViewObject.Destination);
    }
}
