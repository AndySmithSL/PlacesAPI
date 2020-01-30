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
    public class RouteLegController : BaseController<RouteLeg, TravelContext>
    {
        #region Constructor

        public RouteLegController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<RouteLegListView>> GetItems()
        {
            return await GetViewsAsync<RouteLegListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<RouteLegItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<RouteLeg> LoadDataAccess()
        {
            return new DataAccess<RouteLeg>(Context, Context.RouteLeg);
        }

        protected override Func<IEnumerable<RouteLeg>> GetItemsFunction()
        {
            return () => Context
                        .RouteLeg
                        .Include(x => x.Route)
                        .Include(x => x.Origin)
                        .Include(x => x.Destination)
                        .AsEnumerable()
                        .OrderBy(x => x.Route.Name);
        }

        protected override Func<int, RouteLeg> GetItemFunction()
        {
            return id => Context
                        .RouteLeg
                        .Include(x => x.Route)
                        .Include(x => x.Origin)
                        .Include(x => x.Destination)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<RouteLeg, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
