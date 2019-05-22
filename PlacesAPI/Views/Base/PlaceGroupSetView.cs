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
    public class PlaceGroupSetView : View<PlaceGroupSet>
    {
        public int Id => ViewObject.Id;

        public int PlaceId => ViewObject.PlaceId;

        public int GroupId => ViewObject.GroupId;

        [JsonIgnore]
        public PlaceView Place => GetView<PlaceView, Place>(ViewObject.Place);

        [JsonIgnore]
        public PlaceGroupView Group => GetView<PlaceGroupView, PlaceGroup>(ViewObject.Group);

        public override string ListName => Place.Name + " : " + Group.Name;
    }
}
