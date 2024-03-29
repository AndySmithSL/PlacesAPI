﻿using PlacesAPI.Code.Classes;
using PlacesAPI.Models;

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
    }
}
