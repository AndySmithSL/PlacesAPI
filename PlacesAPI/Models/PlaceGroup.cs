using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class PlaceGroup
    {
        #region Constructor

        public PlaceGroup()
        {
            PlaceGroupSets = new HashSet<PlaceGroupSet>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        [Display(Name = "Place Group Sets")]
        public ICollection<PlaceGroupSet> PlaceGroupSets { get; set; }

        #endregion Foreign Properties
    }
}
