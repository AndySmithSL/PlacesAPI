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
    public class FlagController : BaseController<Flag, TravelContext>
    {
        #region Constructor

        public FlagController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<FlagListView>> GetItems()
        {
            return await GetViewsAsync<FlagListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<FlagItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<Flag> LoadDataAccess()
        {
            return new DataAccess<Flag>(Context, Context.Flag);
        }

        protected override Func<int, Flag> GetItemFunction()
        {
            return id => Context
                        .Flag
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Continent)
                        .Include(x => x.Territories)
                            .ThenInclude(x => x.Parent)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Flag>> GetItemsFunction()
        {
            return () => Context
                        .Flag
                        //.Include(x => x.Territories)
                         //   .ThenInclude(x => x.Continent)
                        .AsEnumerable()
                        .OrderBy(x => x.Name);
        }

        protected override Func<Flag, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
