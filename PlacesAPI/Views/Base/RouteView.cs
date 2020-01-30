using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.Base
{
    public class RouteView : View<Route>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string Description => ViewObject.Description;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<RouteLegView> RouteLegs => GetViewList<RouteLegView, RouteLeg>(ViewObject.RouteLegs);

        #endregion Foreign Properties

        #region Other Properties

        //[JsonIgnore]
        //public PlaceView Origin => RouteLegs.OrderBy(x => x.Number).ToList().FirstOrDefault()?.Origin;

        //[JsonIgnore]
        //public PlaceView Destination => RouteLegs.OrderBy(x => x.Number).ToList().FirstOrDefault()?.Destination;

        #endregion Other Properties
    }
}
