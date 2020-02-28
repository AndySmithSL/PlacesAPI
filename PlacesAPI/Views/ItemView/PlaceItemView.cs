using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.ItemView
{
    public class PlaceItemView : PlaceView
    {
        public double LatitudeValue => Latitude.HasValue ? Latitude.Value : 0;
        public string LatitudeDegrees => Latitude.HasValue ? GeoAngle.FromDouble(Latitude.Value).ToString("NS") : "--";
        public double LongitudeValue => Longitude.HasValue ? Longitude.Value : 0;
        public string LongitudeDegrees => Longitude.HasValue ? GeoAngle.FromDouble(Longitude.Value).ToString("WE") : "--";
        public int ZoomValue => Zoom.HasValue ? Zoom.Value : 0;
        public string ZoomString => Zoom.HasValue ? Zoom.Value.ToString() : "--";


        public new ICollection<TerritoryListView> Territories => GetViewList<TerritoryListView, Territory>(ViewObject.Territories);

        //public ICollection<PlaceGroupListView> Groups => GetViewList<PlaceGroupListView, PlaceGroup>(ViewObject.PlaceGroups);

        //public ICollection<DriveListView> Drives => GetViewList<DriveListView, Drive>(ViewObject.Drives);

        //public ICollection<DriveLegView> DriveOriginLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DriveOriginLegs);

        //public ICollection<DriveLegView> DriveDestinationLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DriveDestinationLegs);

        //public ICollection<RouteListView> Routes => GetViewList<RouteListView, Route>(ViewObject.Routes);

        //public ICollection<RouteLegListView> RouteOriginLegs => GetViewList<RouteLegListView, RouteLeg>(ViewObject.RouteOriginLegs);

        //public ICollection<RouteLegListView> RouteDestinationLegs => GetViewList<RouteLegListView, RouteLeg>(ViewObject.RouteDestinationLegs);

    }
}
