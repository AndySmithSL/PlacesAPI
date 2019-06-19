using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesAPI.Code.Classes;
using PlacesAPI.Context;
using PlacesAPI.Data;
using PlacesAPI.Models;
using PlacesAPI.Views.ItemView;
using PlacesAPI.Views.ListView;

namespace PlacesAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoryTypeController : BaseController<TerritoryType, TravelContext>
    {
        #region Constructor

        public TerritoryTypeController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<TerritoryTypeListView>> GetItems()
        {
            return await GetViewsAsync<TerritoryTypeListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<TerritoryTypeItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<TerritoryType> LoadDataAccess()
        {
            return new DataAccess<TerritoryType>(Context, Context.TerritoryType);
        }

        protected override Func<int, TerritoryType> GetItemFunction()
        {
            return id => Context
                        .TerritoryType
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Continent)
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Parent)
                                .ThenInclude(x => x.Continent)
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<TerritoryType>> GetItemsFunction()
        {
            return () => Context
                        .TerritoryType
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Continent)
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Parent)
                        .AsEnumerable()
                        .OrderBy(x => x.Type);
        }

        protected override Func<TerritoryType, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
