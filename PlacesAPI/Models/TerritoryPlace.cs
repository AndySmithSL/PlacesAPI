using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class TerritoryPlace
    {
        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Display(Name = "Territory Id")]
        [Required]
        public int TerritoryId { get; set; }

        [Display(Name = "Place Id")]
        [Required]
        public int PlaceId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Territory Territory { get; set; }

        public Place Place { get; set; }

        #endregion Foreign Properties
    }
}
