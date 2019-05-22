using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;

namespace PlacesAPI.Views.Base
{
    public class TerritoryPlaceView : View<TerritoryPlace>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public int TerritoryId => ViewObject.TerritoryId;

        public int PlaceId => ViewObject.PlaceId;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public TerritoryView Territory => GetView<TerritoryView, Territory>(ViewObject.Territory);

        [JsonIgnore]
        public PlaceView Place => GetView<PlaceView, Place>(ViewObject.Place);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Place.Name + " : " + Territory.Name;

        #endregion Other Properties
    }
}
