using System;
using System.Collections.Generic;

namespace Laugicality.Managers
{
    // Copied from DBT v1.0 by Webmilio
    public abstract class Manager<T> where T : IHasUnlocalizedName
    {
        protected readonly List<T> byIndex = new List<T>();
        protected readonly Dictionary<string, T> byNames = new Dictionary<string, T>();


        internal virtual void DefaultInitialize()
        {
            Initialized = true;
        }


        public virtual T Add(T item)
        {
            if (byIndex.Contains(item) || byNames.ContainsKey(item.UnlocalizedName)) return byNames[item.UnlocalizedName];

            byIndex.Add(item);
            byNames.Add(item.UnlocalizedName, item);
            return item;
        }

        public virtual bool Remove(T item)
        {
            if (!byIndex.Contains(item)) return false;

            byIndex.Remove(item);
            byNames.Remove(item.UnlocalizedName);
            return true;
        }

        public void ForAllItems(Action<T> action)
        {
            for (int i = 0; i < byIndex.Count; i++)
                action(byIndex[i]);
        }


        public virtual bool Contains(T item) => byIndex.Contains(item);

        public virtual bool Contains(string unlocalizedName) => byNames.ContainsKey(unlocalizedName);

        public int GetIndex(T item) => byIndex.IndexOf(item);
        public int GetIndex(string unlocalizedName) => GetIndex(byNames[unlocalizedName]);

        internal virtual void Clear()
        {
            byIndex.Clear();
            byNames.Clear();
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => byNames.GetEnumerator();


        public T this[int index] => byIndex[index];

        public T this[string key] => byNames[key];


        public int Count => byIndex.Count;

        public bool Initialized { get; private set; }
    }
}