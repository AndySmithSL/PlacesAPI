using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;

namespace PlacesAPI.Views.Base
{
    public class RouteLegView : View<RouteLeg>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public int Number => ViewObject.Number;
        public int RouteId => ViewObject.RouteId;
        public int OriginId => ViewObject.OriginId;
        public int DestinationId => ViewObject.DestinationId;
        public string Description => ViewObject.Description;

        #endregion Database Properties
    }
}
