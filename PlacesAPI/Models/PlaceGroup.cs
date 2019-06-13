using PlacesAPI.Code.Interfaces;
using PlacesAPI.Code.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PlacesAPI.Models
{
    public partial class PlaceGroup : IIdentifiable
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

        public string Image { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<PlaceGroupSet> PlaceGroupSets { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Place> Places => PlaceGroupSets.Select(f => f.Place).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
