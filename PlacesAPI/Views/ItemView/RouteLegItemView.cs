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
        public double Zoom => CalculateZoom(Distance);

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

        private double CalculateZoom(double? distance)
        {
            if (distance.HasValue)
            {
                if (distance.Value < 10)
                {
                    return 12;
                }
                else if (distance.Value < 25)
                {
                    return 11;
                }
                else if (distance.Value < 50)
                {
                    return 10;
                }
                else if (distance.Value < 75)
                {
                    return 9;
                }
                else if (distance.Value < 150)
                {
                    return 8;
                }
                else if (distance.Value < 450)
                {
                    return 7;
                }
                else if (distance.Value < 700)
                {
                    return 6;
                }
                else if (distance.Value < 1500)
                {
                    return 5;
                }
                else if (distance.Value < 3000)
                {
                    return 4;
                }
                else if (distance.Value < 6000)
                {
                    return 3;
                }
                else if (distance.Value < 10000)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 6;
            }
        }




        //        2 < 10
        //11 10 to 50
        //10 50 to 100
        //9 100 to 150
        //8 150 to 300
        //7 300 to 450
        //6 450 to 700
        //5 700 to 1500
        //4 1500 to 3000
        //3 3000 to 6000
        //2 6000 to 10000 
        //1 > 10000


    }
}
