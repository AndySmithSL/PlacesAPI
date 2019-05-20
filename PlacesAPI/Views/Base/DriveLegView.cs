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

        [Key]
        public int Id => ViewObject.Id;

        [Required]
        public int Number => ViewObject.Number;

        [Required]
        public int DriveId => ViewObject.DriveId;

        [Required]
        public int OriginId => ViewObject.OriginId;

        [Required]
        public int DestinationId => ViewObject.DestinationId;

        public string Description => ViewObject.Description;

        #endregion Database Properties

        #region Foreign Properties

        public DriveView Drive => GetView<DriveView, Drive>(ViewObject.Drive);
        public PlaceView Origin => GetView<PlaceView, Place>(ViewObject.Origin);
        public PlaceView Destination => GetView<PlaceView, Place>(ViewObject.Destination);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Number + "|" + Drive.Name + "|" + Origin.Name + "|" + Destination.Name;

        #endregion Other Properties

        #region Methods



        #endregion Methods
    }
}
