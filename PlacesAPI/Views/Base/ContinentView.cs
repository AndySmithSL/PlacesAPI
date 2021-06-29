using Newtonsoft.Json;
using PlacesAPI.Code.Classes;
using PlacesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlacesAPI.Views.Base
{
    public class ContinentView : View<Continent>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public string Code => ViewObject.Code;
        public int? ParentId => ViewObject.ParentId;

        #endregion Database Properties

        #region Foreign Properties

        //[JsonIgnore]
        //public ContinentView Parent => GetView<ContinentView, Continent>(ViewObject.Parent);

        //[JsonIgnore]
        //public ICollection<ContinentView> Children => GetViewList<ContinentView, Continent>(ViewObject.Children);

        [JsonIgnore]
        public ICollection<TerritoryView> SubContinentTerritories => GetViewList<TerritoryView, Territory>(ViewObject.SubContinentTerritories);

        #endregion Foreign Properties

        #region Other Properties

        //public override string ListName => Name + ":" + Code;

        #endregion Other Properties
    }
}
