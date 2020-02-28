using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;

namespace PlacesAPI.Views.Base
{
    public class RouteLegView : View<RouteLeg>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public int Number => ViewObject.Number;
        public int RouteId => ViewObject.RouteId;
        public int OriginId => ViewObject.OriginId;
        public int DestinationId => ViewObject.DestinationId;
        public string Description => ViewObject.Description;

        #endregion Database Properties

        #region Other Properties

        public double? Distance => CalculateDistance(ViewObject.Origin.Latitude, ViewObject.Origin.Longitude, ViewObject.Destination.Latitude, ViewObject.Destination.Longitude);
        public string DistanceLabel => Distance.HasValue ? String.Format("{0:n}", Distance.Value) + "km" : "--";

        #endregion Other Properties

        #region Methods

        private double? CalculateDistance(double? originLatitude, double? originLongitude, double? destinationLatitude, double? destinationLongitude)
        {
            if (originLatitude.HasValue && originLongitude.HasValue && destinationLatitude.HasValue && destinationLongitude.HasValue)
            {

                return Math.Round(DistanceCalculator.Calculate(originLatitude.Value, originLongitude.Value, destinationLatitude.Value, destinationLongitude.Value, 'K'), 2);
            }
            else
            {
                return null;
            }
        }

        #endregion Methods

    }
}
