using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlacesAPI.Models
{
    public partial class TerritoryType
    {
        #region Constructor

        public TerritoryType()
        {
            Territories = new HashSet<Territory>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<Territory> Territories { get; set; }

        #endregion Foreign Properties
    }
}
