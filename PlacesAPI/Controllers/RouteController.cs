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
    public class RouteController : BaseController<Route, TravelContext>
    {
        #region Constructor

        public RouteController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<RouteListView>> GetItems()
        {
            return await GetViewsAsync<RouteListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<RouteItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<Route> LoadDataAccess()
        {
            return new DataAccess<Route>(Context, Context.Route);
        }

        protected override Func<IEnumerable<Route>> GetItemsFunction()
        {
            return () => Context
                        .Route
                        .Include(x => x.RouteLegs)
                            .ThenInclude(x => x.Origin)
                        .Include(x => x.RouteLegs)
                            .ThenInclude(x => x.Destination)
                        .AsEnumerable()
                        .OrderBy(x => x.Name);
        }

        protected override Func<int, Route> GetItemFunction()
        {
            return id => Context
                        .Route
                        .Include(x => x.RouteLegs)
                            .ThenInclude(x => x.Origin)
                        .Include(x => x.RouteLegs)
                            .ThenInclude(x => x.Destination)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<Route, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
