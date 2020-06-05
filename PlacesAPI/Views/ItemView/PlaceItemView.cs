using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Code.Classes.Elevation;
using PlacesAPI.Code.Classes.Weather;
using PlacesAPI.Code.Constants;
using PlacesAPI.Code.Interfaces;
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
        private IRequestHandler requestHandler = null;

        public double LatitudeValue => Latitude.HasValue ? Latitude.Value : 0;
        public string LatitudeDegrees => Latitude.HasValue ? GeoAngle.FromDouble(Latitude.Value).ToString("NS") : "--";
        public double LongitudeValue => Longitude.HasValue ? Longitude.Value : 0;
        public string LongitudeDegrees => Longitude.HasValue ? GeoAngle.FromDouble(Longitude.Value).ToString("WE") : "--";
        public int ZoomValue => Zoom.HasValue ? Zoom.Value : 0;
        public string ZoomString => Zoom.HasValue ? Zoom.Value.ToString() : "--";


        public new ICollection<TerritoryListView> Territories => GetViewList<TerritoryListView, Territory>(ViewObject.Territories);

        public new ICollection<PlaceGroupListView> Groups => GetViewList<PlaceGroupListView, PlaceGroup>(ViewObject.PlaceGroups);

        public ICollection<DriveListView> Drives => GetViewList<DriveListView, Drive>(ViewObject.Drives);

        public ICollection<DriveLegView> DriveOriginLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DriveOriginLegs);

        public ICollection<DriveLegView> DriveDestinationLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DriveDestinationLegs);

        public ICollection<RouteListView> Routes => GetViewList<RouteListView, Route>(ViewObject.Routes);

        public ICollection<RouteLegListView> RouteOriginLegs => GetViewList<RouteLegListView, RouteLeg>(ViewObject.RouteOriginLegs);

        public ICollection<RouteLegListView> RouteDestinationLegs => GetViewList<RouteLegListView, RouteLeg>(ViewObject.RouteDestinationLegs);


        // Request Handler

        private IRequestHandler RequestHandler => requestHandler ?? (requestHandler = new HttpWebRequestHandler());

        // Weather 

        private string DarkSkyUrl => RequestConstants.DarkSkyUrl + Latitude + ", " + Longitude;

        private string WeatherResponse => RequestHandler.GetResponse(DarkSkyUrl);

        private DarkSkyWeather DarkSkyWeather => JsonConvert.DeserializeObject<DarkSkyWeather>(WeatherResponse);

        public Weather Weather => new Weather(DarkSkyWeather);

        // Elevation

        private string GoogleElevationUrl => RequestConstants.GoogleMapsElevationUrl + "&locations=" + Latitude + "," + Longitude;
        //"https://maps.googleapis.com/maps/api/elevation/json?locations=39.7391536,-104.9847034&key=AIzaSyAiEv5RMy0d7cDM7fhZPHFrBD7weVs1DFc";

        private string ElevationResponse => RequestHandler.GetResponse(GoogleElevationUrl);

        public Elevation Elevation => JsonConvert.DeserializeObject<Elevation>(ElevationResponse);


    }
}
