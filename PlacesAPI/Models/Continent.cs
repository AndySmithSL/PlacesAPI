using PlacesAPI.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Models
{
    public partial class Continent : IIdentifiable
    {
        public Continent()
        {
            Children = new HashSet<Continent>();
            //Territories = new HashSet<Territory>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Parent Id")]
        public int? ParentId { get; set; }

        [Display(Name = "Parent")]
        public Continent Parent { get; set; }

        [Display(Name = "Subcontinents")]
        public ICollection<Continent> Children { get; set; }

        //public ICollection<Territory> Territories { get; set; }
    }
}
