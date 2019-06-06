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
    public class FlagView : View<Flag>
    {
        #region Private Constants

        private const string FLAG_EXTENSION = ".png";

        #endregion Private Constants

        #region Database Properties

        public int Id => ViewObject.Id;

        public string Name => ViewObject.Name;

        public string Code => ViewObject.Code;

        public string Description => ViewObject.Description;

        public DateTime? StartDate => ViewObject.StartDate;

        public DateTime? EndDate => ViewObject.EndDate;

        public bool Active => ViewObject.Active;

        public bool Complete => ViewObject.Complete;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<TerritoryView> Territories => GetViewList<TerritoryView, Territory>(ViewObject.Territories);

        #endregion Foreign Properties

        #region Other Properties

        //public override string ListName => Name + " : " + Code;

        public string Image => Code + FLAG_EXTENSION;

        public string StartDateLabel => GetDateLabel(StartDate);

        public string EndDateLabel => GetDateLabel(EndDate);

        #endregion Other Properties

        #region Methods

        private string GetDateLabel(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("dd MMMM yyyy");
            }
            else
            {
                return "--";
            }
        }

        #endregion Methods
    }
}
