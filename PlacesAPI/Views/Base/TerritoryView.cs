﻿using Newtonsoft.Json;
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
    public class TerritoryView : View<Territory>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string FullName => ViewObject.FullName;

        public string NativeName => ViewObject.NativeName;

        public int? ContinentId => ViewObject.ContinentId;

        public int? ParentId => ViewObject.ParentId;

        public int? FlagId => ViewObject.FlagId;

        public int? Population => ViewObject.Population;

        public decimal? Area => ViewObject.Area;

        public string Isocode => ViewObject.Isocode;

        public double? Latitude => ViewObject.Latitude;

        public double? Longitude => ViewObject.Longitude;

        public int? Zoom => ViewObject.Zoom;

        public int? TerritoryTypeId => ViewObject.TerritoryTypeId;

        public string GeoChartLevel => ViewObject.GeoChartLevel;

        public bool Complete => ViewObject.Complete;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public TerritoryView Parent => GetView<TerritoryView, Territory>(ViewObject.Parent);

        [JsonIgnore]
        public ContinentView Continent => GetView<ContinentView, Continent>(ViewObject.Continent);

        [JsonIgnore]
        public TerritoryTypeView TerritoryType => GetView<TerritoryTypeView, TerritoryType>(ViewObject.TerritoryType);

        [JsonIgnore]
        public FlagView Flag => GetView<FlagView, Flag>(ViewObject.Flag);

        [JsonIgnore]
        public ICollection<TerritoryView> Children => GetViewList<TerritoryView, Territory>(ViewObject.Children);

        [JsonIgnore]
        public ICollection<TerritoryPlaceView> TerritoryPlaces => GetViewList<TerritoryPlaceView, TerritoryPlace>(ViewObject.TerritoryPlaces);

        #endregion Foreign Properties

        #region Other Properties

        public string PopulationLabel => Population.HasValue ? Population.Value.ToString("N0") : "--";
        public string AreaLabel => Area.HasValue ? Area.Value.ToString("N0") + " km²" : "--";
        public string PartOf => ParentId.HasValue ? ViewObject.Parent?.Name : ViewObject.Continent?.Name;

        public string CountryIso
        {
            get
            {
                if (ParentId.HasValue && !String.IsNullOrEmpty(GeoChartLevel))
                {
                    if ((Code.Enums.GeoChartLevel)Enum.Parse(typeof(Code.Enums.GeoChartLevel), GeoChartLevel) == Code.Enums.GeoChartLevel.countries)
                    {
                        return Isocode;
                    }
                    else
                    {
                        return ViewObject.Parent.Isocode;
                    }
                }
                else
                {
                    return Isocode;
                }
            }
        }

        public string DetailsName => string.IsNullOrEmpty(NativeName) ? FullName : NativeName + " | " + FullName;


        [JsonIgnore]
        public ICollection<PlaceView> Places => GetViewList<PlaceView, Place>(ViewObject.Places);

        [JsonIgnore]
        public ICollection<PlaceView> ChildrenPlaces => GetViewList<PlaceView, Place>(ViewObject.ChildrenPlaces);

        #endregion Other Properties
    }
}
