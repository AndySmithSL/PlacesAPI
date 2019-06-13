using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PlacesAPI.Code.Util;
using Newtonsoft.Json;

namespace PlacesAPI.Views.Base
{
    public class PlaceGroupView : View<PlaceGroup>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string Description => ViewObject.Description;

        public string Icon => ViewObject.Icon;

        public string Image => ViewObject.Image;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<PlaceGroupSetView> PlaceGroupSets => GetViewList<PlaceGroupSetView, PlaceGroupSet>(ViewObject.PlaceGroupSets);

        #endregion Foreign Properties

        #region Other Properties

        //public override string ListName => Name;

        //[JsonIgnore]
        //public ICollection<PlaceView> Places => PlaceGroupSets.Select(x => x.Place).Distinct(x => x.Id).ToList();

        #endregion Other Properties
    }
}
