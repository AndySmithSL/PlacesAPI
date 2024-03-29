﻿using Microsoft.AspNetCore.Cors;
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
    public class TerritoryController : BaseController<Territory, TravelContext>
    {
        #region Constructor

        public TerritoryController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<TerritoryListView>> GetItems()
        {
            return await GetViewsAsync<TerritoryListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<TerritoryItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<Territory> LoadDataAccess()
        {
            return new DataAccess<Territory>(Context, Context.Territory);
        }

        protected override Func<int, Territory> GetItemFunction()
        {
            return id => Context
                        .Territory
                        .Include(x => x.Parent)
                            .ThenInclude(x => x.Continent)
                        .Include(x => x.Parent)
                            .ThenInclude(x => x.Parent)
                        .Include(x => x.Parent)
                            .ThenInclude(x => x.Flag)
                        .Include(x => x.Parent)
                            .ThenInclude(x => x.TerritoryType)
                        .Include(x => x.Continent)
                            .ThenInclude(x => x.Parent)
                        .Include(x => x.TerritoryType)
                        .Include(x => x.Flag)
                        .Include(x => x.TerritoryPlaces)
                            .ThenInclude(x => x.Place)
                        .Include(x => x.Children)
                            .ThenInclude(x => x.Flag)
                        .Include(x => x.Children)
                            .ThenInclude(x => x.TerritoryPlaces)
                                .ThenInclude(x => x.Place)
                        .Include(x => x.Children)
                            .ThenInclude(x => x.TerritoryType)
                        .Include(x => x.Children)
                            .ThenInclude(x => x.Continent)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Territory>> GetItemsFunction()
        {
            return () => Context
                        .Territory
                        .Where(x => x.Complete == true)
                        .Include(x => x.Continent)
                        .Include(x => x.Parent)
                        .Include(x => x.Flag)
                        .Include(x => x.TerritoryType)
                        .Include(x => x.TerritoryPlaces)
                            .ThenInclude(x => x.Place)
                        .AsEnumerable()
                        .OrderBy(x => x.Name);
        }

        protected override Func<Territory, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
