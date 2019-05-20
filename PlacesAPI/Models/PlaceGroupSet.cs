using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class PlaceGroupSet
    {
        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Place Id")]
        public int PlaceId { get; set; }

        [Required]
        [Display(Name = "Group Id")]
        public int GroupId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Place Place { get; set; }

        public PlaceGroup Group { get; set; }

        #endregion Foreign Properties
    }
}
