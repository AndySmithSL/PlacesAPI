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
    public class DriveLegView : View<DriveLeg>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public int Number => ViewObject.Number;

        public int DriveId => ViewObject.DriveId;

        public int OriginId => ViewObject.OriginId;

        public int DestinationId => ViewObject.DestinationId;

        public string Description => ViewObject.Description;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public DriveView Drive => GetView<DriveView, Drive>(ViewObject.Drive);

        [JsonIgnore]
        public PlaceView Origin => GetView<PlaceView, Place>(ViewObject.Origin);

        [JsonIgnore]
        public PlaceView Destination => GetView<PlaceView, Place>(ViewObject.Destination);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Number + "|" + Drive.Name + "|" + Origin.Name + "|" + Destination.Name;

        #endregion Other Properties
    }
}
