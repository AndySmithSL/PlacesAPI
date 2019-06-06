using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PlacesAPI.Code.Util;
using Newtonsoft.Json;

namespace PlacesAPI.Views.Base
{
    public class PlaceView : View<Place>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string LocalName => ViewObject.LocalName;

        public double? Latitude => ViewObject.Latitude;

        public double? Longitude => ViewObject.Longitude;

        public int? Zoom => ViewObject.Zoom;

        public bool Complete => ViewObject.Complete;

        #endregion Database Properties

        #region Foreign Properties

        //[JsonIgnore]
        //public ICollection<TerritoryPlaceView> TerritoryPlaces => GetViewList<TerritoryPlaceView, TerritoryPlace>(ViewObject.TerritoryPlaces);

        //[JsonIgnore]
        //public ICollection<PlaceGroupSetView> PlaceGroupSets => GetViewList<PlaceGroupSetView, PlaceGroupSet>(ViewObject.PlaceGroupSets);

        //[JsonIgnore]
        //public ICollection<DriveLegView> OriginLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.OriginLegs);

        //[JsonIgnore]
        //public ICollection<DriveLegView> DestinationLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DestinationLegs);

        #endregion Foreign Properties

        #region Other Properties

        public string DetailsName => string.IsNullOrEmpty(LocalName) ? "--" : LocalName;

        [JsonIgnore]
        public ICollection<TerritoryView> Territories => GetViewList<TerritoryView, Territory>(ViewObject.Territories);

        //[JsonIgnore]
        //public ICollection<PlaceGroupView> Groups => PlaceGroupSets.Select(x => x.PlaceGroup).Distinct(x => x.Id).ToList();

        #endregion Other Properties
    }
}
