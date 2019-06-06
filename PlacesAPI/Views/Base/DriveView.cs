using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.Base
{
    public class DriveView : View<Drive>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string Description => ViewObject.Description;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<DriveLegView> DriveLegs => GetViewList<DriveLegView, DriveLeg>(ViewObject.DriveLegs);

        #endregion Foreign Properties

        #region Other Properties

        //public override string ListName => Name;

        #endregion Other Properties
    }
}
