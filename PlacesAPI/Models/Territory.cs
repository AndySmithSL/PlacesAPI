using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class Territory
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

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Native Name")]
        public string NativeName { get; set; }

        [Display(Name = "Continent")]
        public int? ContinentId { get; set; }

        [Display(Name = "Parent")]
        public int? ParentId { get; set; }

        [Display(Name = "Flag")]
        public int? FlagId { get; set; }

        public int? Population { get; set; }

        public decimal? Area { get; set; }

        [Display(Name = "ISO")]
        public string Isocode { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Zoom { get; set; }

        [Display(Name = "Territory Type Id")]
        public int TerritoryTypeId { get; set; }

        [Display(Name = "Geochart Level")]
        public string GeoChartLevel { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Continent Continent { get; set; }

        public Territory Parent { get; set; }

        [Display(Name = "Territory Type")]
        public TerritoryType TerritoryType { get; set; }

        public Flag Flag { get; set; }

        public ICollection<Territory> Children { get; set; }

        [Display(Name = "Territory Places")]
        public ICollection<TerritoryPlace> TerritoryPlaces { get; set; }

        #endregion Foreign Properties
    }
}
