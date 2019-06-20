using PlacesAPI.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        #region Other Properties

        [NotMapped]
        public Place Origin => DriveLegs.OrderBy(x => x.Number).ToList().FirstOrDefault().Origin;

        [NotMapped]
        public Place Destination => DriveLegs.OrderByDescending(x => x.Number).ToList().FirstOrDefault().Destination;

        [NotMapped]
        public List<Place> Waypoints => GetWaypoints();
        
        #endregion Other Properties

        #region Methods

        private List<Place> GetWaypoints()
        {
            List<Place> results = new List<Place>();

            bool isFirst = true;

            foreach (var item in DriveLegs)
            {
                if (!isFirst)
                {
                    results.Add(item.Origin);
                }
                isFirst = false;
            }

            return results;
        }

        #endregion Methods
    }
}
