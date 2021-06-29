using PlacesAPI.Code.Interfaces;
using PlacesAPI.Code.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PlacesAPI.Models
{
    public partial class Continent : IIdentifiable
    {
        #region Constructor

        public Continent()
        {
            Children = new HashSet<Continent>();
            Territories = new HashSet<Territory>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Required]
        public string Code { get; set; }

        public int? ParentId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Continent Parent { get; set; }

        public ICollection<Continent> Children { get; set; }

        public ICollection<Territory> Territories { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Territory> SubContinentTerritories => Children.SelectMany(f => f.Territories).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
