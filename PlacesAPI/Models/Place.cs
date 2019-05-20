using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Models
{
    public partial class Place
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

        [Display(Name = "Local Name")]
        public string LocalName { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Zoom { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        [Display(Name = "Territory Places")]
        public ICollection<TerritoryPlace> TerritoryPlaces { get; set; }

        [Display(Name = "Place Group Sets")]
        public ICollection<PlaceGroupSet> PlaceGroupSets { get; set; }

        [Display(Name = "Origin Legs")]
        public ICollection<DriveLeg> OriginLegs { get; set; }

        [Display(Name = "Destination Legs")]
        public ICollection<DriveLeg> DestinationLegs { get; set; }

        #endregion Foreign Properties
    }
}
