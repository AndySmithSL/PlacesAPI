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
    public class DriveLegController : BaseController<DriveLeg, TravelContext>
    {
        #region Constructor

        public DriveLegController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<DriveLegListView>> GetItems()
        {
            return await GetViewsAsync<DriveLegListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<DriveLegItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<DriveLeg> LoadDataAccess()
        {
            return new DataAccess<DriveLeg>(Context, Context.DriveLeg);
        }

        protected override Func<IEnumerable<DriveLeg>> GetItemsFunction()
        {
            return () => Context
                        .DriveLeg
                        .Include(x => x.Drive)
                        .Include(x => x.Origin)
                        .Include(x => x.Destination)
                        .AsEnumerable()
                        .OrderBy(x => x.Drive.Name);
        }

        protected override Func<int, DriveLeg> GetItemFunction()
        {
            return id => Context
                        .DriveLeg
                        .Include(x => x.Drive)
                        .Include(x => x.Origin)
                        .Include(x => x.Destination)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<DriveLeg, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
