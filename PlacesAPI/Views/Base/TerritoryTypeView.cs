using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Views.Base
{
    public class TerritoryTypeView : View<TerritoryType>
    {
        #region Database Properties

        public int Id => ViewObject.Id;

        public string Type => ViewObject.Type;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<TerritoryView> Territories => GetViewList<TerritoryView, Territory>(ViewObject.Territories);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Type;

        #endregion Other Properties
    }
}
