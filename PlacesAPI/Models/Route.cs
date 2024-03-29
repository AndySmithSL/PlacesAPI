﻿using PlacesAPI.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PlacesAPI.Models
{
    public partial class Route : IIdentifiable
    {
        #region Constructor

        public Route()
        { 
            RouteLegs = new HashSet<RouteLeg>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        [Display(Name = "Route Legs")]
        public ICollection<RouteLeg> RouteLegs { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public Place Origin => RouteLegs.OrderBy(x => x.Number).ToList().FirstOrDefault().Origin;

        [NotMapped]
        public Place Destination => RouteLegs.OrderByDescending(x => x.Number).ToList().FirstOrDefault().Destination;

        [NotMapped]
        public List<Place> Waypoints => GetWaypoints();

        [NotMapped]
        public List<Place> Places => GetPlaces();

        #endregion Other Properties

        #region Methods

        private List<Place> GetWaypoints()
        {
            List<Place> results = new List<Place>();

            bool isFirst = true;

            foreach (var item in RouteLegs)
            {
                if (!isFirst)
                {
                    results.Add(item.Origin);
                }
                isFirst = false;
            }

            return results;
        }

        private List<Place> GetPlaces()
        {
            List<Place> results = new List<Place>();

            foreach (var leg in RouteLegs)
            {
                if (!results.Contains(leg.Origin))
                {
                    results.Add(leg.Origin);
                }
                if (!results.Contains(leg.Destination))
                {
                    results.Add(leg.Destination);
                }
            }

            return results;
        }

        #endregion Methods
    }
}
