using PlacesAPI.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class Drive : IIdentifiable
    {
        #region Constructor

        public Drive()
        {
            DriveLegs = new HashSet<DriveLeg>();
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

        [Display(Name = "Drive Legs")]
        public ICollection<DriveLeg> DriveLegs { get; set; }

        #endregion Foreign Properties
    }
}
