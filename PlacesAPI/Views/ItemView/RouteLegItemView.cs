using System;
using PlacesAPI.Models;
using PlacesAPI.Views.Base;
using PlacesAPI.Views.ListView;

namespace PlacesAPI.Views.ItemView
{
    public class RouteLegItemView: RouteLegView
    {
        public RouteItemView Route => GetView<RouteItemView, Route>(ViewObject.Route);
        public PlaceListView Origin => GetView<PlaceListView, Place>(ViewObject.Origin);
        public PlaceListView Destination => GetView<PlaceListView, Place>(ViewObject.Destination);

        public double CentreLatitude => CalculateCentre(Origin.Latitude, Destination.Latitude);
        public double CentreLongitude => CalculateCentre(Origin.Longitude, Destination.Longitude);

        private double CalculateCentre(double? valueOne, double? valueTwo)
        {
            if(valueOne.HasValue && valueTwo.HasValue)
            {
                double absolute = Math.Abs(valueOne.Value - valueTwo.Value) / 2;
                
                if(valueOne.Value < valueTwo.Value)
                {
                    return valueOne.Value + absolute;
                }
                else
                {
                    return valueOne.Value - absolute;
                }
            }
            else if(valueOne.HasValue)
            {
                return valueOne.Value;
            }
            else if(valueTwo.HasValue)
            {
                return valueTwo.Value;
            }
            else
            {
                return default(double);
            }
        }
    }
}
