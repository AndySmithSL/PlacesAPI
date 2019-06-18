using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesAPI.Code.Interfaces;
using PlacesAPI.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacesAPI.Code.Classes
{
    public abstract class BaseController<T, TContext> : ControllerBase
         where T : class, IIdentifiable
         where TContext : DbContext
    {
        #region Private Declarations

        private DataAccess<T> dataAccess = null;

        private TContext context = null;

        #endregion Private Declarations

        #region Properties

        public DataAccess<T> DataAccess
        {
            get => dataAccess ?? (dataAccess = LoadDataAccess());
            set => dataAccess = value;
        }

        public TContext Context
        {
            get => context ?? throw new NullReferenceException("The Context object has not been set.");
            set => context = value;
        }

        public T Item { get; set; } = default(T);

        #endregion Properties

        #region Constructor

        public BaseController(TContext context)
        {
            Context = context;
        }

        #endregion Constructor

        #region Methods

        #region Get Items

        public async Task<IActionResult> GetItemAsync(int id)
        {
            var item = await DataAccess.GetItemAsync(id, GetItemFunction());
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await DataAccess.GetItemsAsync(GetItemsFunction());
        }

        #endregion Get Items

        #region Get Views

        public async Task<IActionResult> GetViewAsync<TView>(int id)
            where TView : IView<T>, new()
        {
            var item = await DataAccess.GetViewAsync<TView>(id, GetItemFunction());
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public async Task<IEnumerable<TView>> GetViewsAsync<TView>()
            where TView : IView<T>, new()
        {
            return await DataAccess.GetViewsAsync<TView>(GetItemsFunction());
        }

        public async Task<IEnumerable<TView>> GetViewsAsync<TView>(Func<IEnumerable<T>> function)
            where TView : IView<T>, new()
        {
            return await DataAccess.GetViewsAsync<TView>(function);
        }

        #endregion Get Views

        #region Post

        public IActionResult Post(T item)
        {
            Create(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item);
        }

        public async Task<ActionResult<T>> PostAsync(T item)
        {
            await CreateAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item);
        }

        #endregion Post

        #region Put

        public IActionResult Put(int itemId, T item)
        {
            Update(item);
            return NoContent();
        }

        public async Task<IActionResult> PutAsync(int itemId, T item)
        {
            if (itemId != item.Id)
            {
                return BadRequest();
            }
            await UpdateAsync(item);
            return NoContent();
        }

        #endregion Put

        #region Delete

        public IActionResult Delete(int id)
        {
            var item = DataAccess.GetItem(id, GetItemFunction());
            if (item == null)
            {
                return NotFound();
            }
            Delete(item);
            return NoContent();
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await DataAccess.GetItemAsync(id, GetItemFunction());
            if (item == null)
            {
                return NotFound();
            }
            await DeleteAsync(item);
            return NoContent();
        }

        #endregion Delete

        #region DataAccess

        public void Create(T item)
        {
            DataAccess.Add(item);
            DataAccess.Save();
        }

        public Task<int> CreateAsync(T item)
        {
            DataAccess.Add(item);
            return DataAccess.SaveAsync();
        }

        public void Update(T item)
        {
            DataAccess.Update(item);
            DataAccess.Save();
        }

        public async Task<int> UpdateAsync(T item)
        {
            DataAccess.Update(item);
            return await DataAccess.SaveAsync();
        }

        public void Delete(T item)
        {
            DataAccess.Delete(item);
            DataAccess.Save();
        }

        public async Task<int> DeleteAsync(T item)
        {
            DataAccess.Delete(item);
            return await DataAccess.SaveAsync();
        }

        #endregion DataAccess

        #region Abstract Methods

        protected abstract DataAccess<T> LoadDataAccess();
        protected abstract Func<int, T> GetItemFunction();
        protected abstract Func<IEnumerable<T>> GetItemsFunction();
        protected abstract Func<T, bool> GetExistsFunc(int id);

        #endregion Abstract Methods

        #endregion Methods
    }
}
