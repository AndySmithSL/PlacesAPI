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
            DriveOriginLegs = new HashSet<DriveLeg>();
            DriveDestinationLegs = new HashSet<DriveLeg>();
            RouteOriginLegs = new HashSet<RouteLeg>();
            RouteDestinationLegs = new HashSet<RouteLeg>();
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

        [Required]
        public bool Complete { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<TerritoryPlace> TerritoryPlaces { get; set; }

        public ICollection<PlaceGroupSet> PlaceGroupSets { get; set; }

        public ICollection<DriveLeg> DriveOriginLegs { get; set; }

        public ICollection<DriveLeg> DriveDestinationLegs { get; set; }

        public ICollection<RouteLeg> RouteOriginLegs { get; set; }

        public ICollection<RouteLeg> RouteDestinationLegs { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Territory> Territories => TerritoryPlaces.Select(f => f.Territory).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<PlaceGroup> PlaceGroups => PlaceGroupSets.Select(f => f.PlaceGroup).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Drive> OriginDrives => DriveOriginLegs.Select(f => f.Drive).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Drive> DestinationDrives => DriveDestinationLegs.Select(f => f.Drive).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Drive> Drives => OriginDrives.Union(DestinationDrives).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Route> OriginRoutes => RouteOriginLegs.Select(f => f.Route).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Route> DestinationRoutes => RouteDestinationLegs.Select(f => f.Route).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Route> Routes => OriginRoutes.Union(DestinationRoutes).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
