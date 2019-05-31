using PlacesAPI.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PlacesAPI.Code.Util;

namespace PlacesAPI.Models
{
    public partial class Place : IIdentifiable
    {
        #region Constructor

        public Place()
        {
            TerritoryPlaces = new HashSet<TerritoryPlace>();
            PlaceGroupSets = new HashSet<PlaceGroupSet>();
            OriginLegs = new HashSet<DriveLeg>();
            DestinationLegs = new HashSet<DriveLeg>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LocalName { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Zoom { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<TerritoryPlace> TerritoryPlaces { get; set; }

        public ICollection<PlaceGroupSet> PlaceGroupSets { get; set; }

        public ICollection<DriveLeg> OriginLegs { get; set; }

        public ICollection<DriveLeg> DestinationLegs { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Territory> Territories => TerritoryPlaces.Select(f => f.Territory).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
