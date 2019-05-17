using Microsoft.EntityFrameworkCore;
using PlacesAPI.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesAPI.Data
{
    public class DataAccess<T>
        where T : class
    {
        #region Private Declarations

        private DbSet<T> dataSet = null;
        private DbContext context = null;

        #endregion Private Declarations

        #region Public Properties

        public DbSet<T> DataSet
        {
            get => dataSet ?? throw new NullReferenceException("The dataSet has not been set.");
            set => dataSet = value;
        }

        public DbContext Context
        {
            get => context ?? throw new NullReferenceException("The context object has not been set.");
            set => context = value;
        }

        #endregion Public Properties

        #region Constructor

        public DataAccess(DbContext context, DbSet<T> dataSet)
        {
            Context = context;
            DataSet = dataSet;
        }

        #endregion Constructor

        #region Methods

        #region Get Items

        public virtual IEnumerable<T> GetItems(Func<IEnumerable<T>> itemFunc)
        {
            return itemFunc();
        }

        public Task<IEnumerable<T>> GetItemsAsync(Func<IEnumerable<T>> itemFunc)
        {
            return Task<IEnumerable<T>>.Factory.StartNew(() => GetItems(itemFunc));
        }

        #endregion Get Items

        #region Get Item

        public T GetItem(int id, Func<int, T> itemFunc)
        {
            return itemFunc(id);
        }

        public Task<T> GetItemAsync(int id, Func<int, T> itemFunc)
        {
            return Task<T>.Factory.StartNew(() => GetItem(id, itemFunc));
        }

        #endregion Get Item

        #region Generic Get View / Views

        public ICollection<TView> GetViews<TView>(Func<IEnumerable<T>> function)
            where TView : IView<T>, new()
        {
            ICollection<TView> result = new List<TView>();
            foreach (var item in function())
            {
                TView view = new TView();
                view.ViewObject = item;
                result.Add(view);
            }
            return result;
        }

        public Task<ICollection<TView>> GetViewsAsync<TView>(Func<IEnumerable<T>> function)
            where TView : IView<T>, new()
        {
            return Task<ICollection<TView>>.Factory.StartNew(() => GetViews<TView>(function));
        }

        public TView GetView<TView>(int id, Func<int, T> itemFunc)
            where TView : IView<T>, new()
        {
            TView view = new TView();
            view.ViewObject = GetItem(id, itemFunc);
            return view;
        }

        public Task<TView> GetViewAsync<TView>(int id, Func<int, T> function)
            where TView : IView<T>, new()
        {
            return Task<TView>.Factory.StartNew(() => GetView<TView>(id, function));
        }

        #endregion Generic Get View / Views

        #region Other Methods

        public bool ItemExists(Func<T, bool> predicate)
        {
            return DataSet.Any(predicate);
        }

        public void Add(T item)
        {
            DataSet.Add(item);
        }

        public void Delete(T item)
        {
            DataSet.Remove(item);
        }

        public void Update(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        #endregion Other Methods

        #endregion Methods
    }
}
