using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesAPI.Code.Classes;
using PlacesAPI.Context;
using PlacesAPI.Data;
using PlacesAPI.Models;
using PlacesAPI.Views.ItemView;
using PlacesAPI.Views.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceGroupController : BaseController<PlaceGroup, TravelContext>
    {
        #region Constructor

        public PlaceGroupController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<PlaceGroupListView>> GetItems()
        {
            return await GetViewsAsync<PlaceGroupListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<PlaceGroupItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<PlaceGroup> LoadDataAccess()
        {
            return new DataAccess<PlaceGroup>(Context, Context.PlaceGroup);
        }

        protected override Func<int, PlaceGroup> GetItemFunction()
        {
            return id => Context
                        .PlaceGroup
                        .Include(x => x.PlaceGroupSets)
                            .ThenInclude(x => x.Place)
                                .ThenInclude(x => x.TerritoryPlaces)
                                    .ThenInclude(x => x.Territory)
                                        .ThenInclude(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<PlaceGroup>> GetItemsFunction()
        {
            return () => Context
                        .PlaceGroup
                        .Include(x => x.PlaceGroupSets)
                            .ThenInclude(x => x.Place)
                        .AsEnumerable()
                        .OrderBy(x => x.Name);
        }

        protected override Func<PlaceGroup, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
