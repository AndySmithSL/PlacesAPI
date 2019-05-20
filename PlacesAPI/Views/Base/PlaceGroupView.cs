using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PlacesAPI.Code.Util;

namespace PlacesAPI.Views.Base
{
    public class PlaceGroupView : View<PlaceGroup>
    {
        #region Database Properties

        [Key]
        public int Id => ViewObject.Id;

        [Required]
        public string Name => ViewObject.Name;

        public string Description => ViewObject.Description;

        [StringLength(50)]
        public string Icon => ViewObject.Icon;

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<PlaceGroupSetView> PlaceGroupSets => GetViewList<PlaceGroupSetView, PlaceGroupSet>(ViewObject.PlaceGroupSets);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Name;

        public ICollection<PlaceView> Places => PlaceGroupSets.Select(x => x.Place).Distinct(x => x.Id).ToList();

        #endregion Other Properties
    }
}
