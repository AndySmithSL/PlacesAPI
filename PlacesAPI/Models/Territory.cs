using PlacesAPI.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using PlacesAPI.Code.Util;

namespace PlacesAPI.Models
{
    public partial class Territory : IIdentifiable
    {
        #region Constructor

        public Territory()
        {
            Children = new HashSet<Territory>();
            TerritoryPlaces = new HashSet<TerritoryPlace>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string NativeName { get; set; }

        public int? ContinentId { get; set; }

        public int? ParentId { get; set; }

        public int? FlagId { get; set; }

        public int? Population { get; set; }

        public decimal? Area { get; set; }

        public string Isocode { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Zoom { get; set; }

        public int TerritoryTypeId { get; set; }

        public string GeoChartLevel { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Continent Continent { get; set; }

        public Territory Parent { get; set; }

        public TerritoryType TerritoryType { get; set; }

        public Flag Flag { get; set; }

        public ICollection<Territory> Children { get; set; }

        public ICollection<TerritoryPlace> TerritoryPlaces { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Place> Places => TerritoryPlaces.Select(f => f.Place).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
