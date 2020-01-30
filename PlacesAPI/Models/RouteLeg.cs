using PlacesAPI.Code.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public class RouteLeg : IIdentifiable
    {
        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Route Id")]
        public int RouteId { get; set; }

        [Required]
        [Display(Name = "Origin Id")]
        public int OriginId { get; set; }

        [Required]
        [Display(Name = "Destination Id")]
        public int DestinationId { get; set; }

        public string Description { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Route Route { get; set; }

        public Place Origin { get; set; }

        public Place Destination { get; set; }

        #endregion Foreign Properties
    }
}
