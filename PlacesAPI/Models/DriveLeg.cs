using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public class DriveLeg
    {
        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Drive Id")]
        public int DriveId { get; set; }
        
        [Required]
        [Display(Name = "Origin Id")]
        public int OriginId { get; set; }

        [Required]
        [Display(Name = "Destination Id")]
        public int DestinationId { get; set; }
        
        public string Description { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Drive Drive { get; set; }

        public Place Origin { get; set; }

        public Place Destination { get; set; }

        #endregion Foreign Properties
    }
}
