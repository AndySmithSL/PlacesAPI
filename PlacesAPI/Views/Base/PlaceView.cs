using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PlacesAPI.Code.Util;

namespace PlacesAPI.Views.Base
{
    public class PlaceView : View<Place>
    {
        #region Database Properties

        [Key]
        public int Id => ViewObject.Id;

        [Required]
        public string Name => ViewObject.Name;

        [Display(Name = "Local Name")]
        public string LocalName => ViewObject.LocalName;

        public double? Latitude => ViewObject.Latitude;

        public double? Longitude => ViewObject.Longitude;

        public int? Zoom => ViewObject.Zoom;

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<TerritoryPlaceView> TerritoryPlaces => GetViewList<TerritoryPlaceView, TerritoryPlace>(ViewObject.TerritoryPlaces);

        public ICollection<PlaceGroupSetView> PlaceGroupSets => GetViewList<PlaceGroupSetView, PlaceGroupSet>(ViewObject.PlaceGroupSets);

        public ICollection<DriveLegView> OriginLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.OriginLegs);

        public ICollection<DriveLegView> DestinationLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DestinationLegs);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Name;

        public string DetailsName => string.IsNullOrEmpty(LocalName) ? "--" : LocalName;

        public double LatitudeValue => Latitude.HasValue ? Latitude.Value : 0;

        public string LatitudeDegrees => Latitude.HasValue ? GeoAngle.FromDouble(Latitude.Value).ToString("NS") : "--";

        public double LongitudeValue => Longitude.HasValue ? Longitude.Value : 0;

        public string LongitudeDegrees => Longitude.HasValue ? GeoAngle.FromDouble(Longitude.Value).ToString("WE") : "--";

        public int ZoomValue => Zoom.HasValue ? Zoom.Value : 0;
        public string ZoomString => Zoom.HasValue ? Zoom.Value.ToString() : "--";

        public ICollection<TerritoryView> Territories => TerritoryPlaces.Select(x => x.Territory).Distinct(x => x.Id).ToList();

        public ICollection<PlaceGroupView> Groups => PlaceGroupSets.Select(x => x.Group).Distinct(x => x.Id).ToList();

        //public string FlagImage
        //{
        //    get
        //    {
        //        if(Territories.Count > 0)
        //        {
        //            return Territories.FirstOrDefault().FlagImage;
        //        }
        //        else
        //        {
        //            return "/images/flags/BLANK.png";
        //        }
        //    }
        //}


        #endregion Other Properties
    }
}
