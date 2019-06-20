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
    public class DriveController : BaseController<Drive, TravelContext>
    {
        #region Constructor

        public DriveController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<DriveListView>> GetItems()
        {
            return await GetViewsAsync<DriveListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<DriveItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<Drive> LoadDataAccess()
        {
            return new DataAccess<Drive>(Context, Context.Drive);
        }

        protected override Func<IEnumerable<Drive>> GetItemsFunction()
        {
            return () => Context
                        .Drive
                        .Include(x => x.DriveLegs)
                            .ThenInclude(x => x.Origin)
                        .Include(x => x.DriveLegs)
                            .ThenInclude(x => x.Destination)
                        .AsEnumerable()
                        .OrderBy(x => x.Name);
        }

        protected override Func<int, Drive> GetItemFunction()
        {
            return id => Context
                        .Drive
                        .Include(x => x.DriveLegs)
                            .ThenInclude(x => x.Origin)
                        .Include(x => x.DriveLegs)
                            .ThenInclude(x => x.Destination)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<Drive, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
