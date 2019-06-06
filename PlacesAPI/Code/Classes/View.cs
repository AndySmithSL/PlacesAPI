using Newtonsoft.Json;
using PlacesAPI.Code.Interfaces;
using System.Collections.Generic;

namespace PlacesAPI.Code.Classes
{
    public abstract class View<T> : IView<T>
    {
        public View() { }

        public View(T viewObject)
        {
            ViewObject = viewObject;
        }

        [JsonIgnore]
        public T ViewObject { get; set; }

        //public abstract string ListName { get; }

        protected ICollection<TView> GetViewList<TView, TObject>(IEnumerable<TObject> list)
            where TView : IView<TObject>, new()
        {
            ICollection<TView> result = new List<TView>();

            foreach (var item in list)
            {
                TView view = new TView();
                view.ViewObject = item;
                result.Add(view);
            }

            return result;
        }

        protected TView GetView<TView, TObject>(TObject item)
            where TView : View<TObject>, new()
        {
            if (item != null)
            {
                TView result = new TView();
                result.ViewObject = item;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
