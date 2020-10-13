using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace Gauge.CSharp.Lib
{
    public class ScenarioDataStore
    {
        private static ThreadLocal<ConcurrentDictionary<object, object>> store = new ThreadLocal<ConcurrentDictionary<object, object>>(() => new ConcurrentDictionary<object, object>());

        public static object Get(string key)
        {
            return CommonDataStore.WithDataStore(store).Get(key);
            //lock (store)
            //{
            //    object outVal;
            //    var valueExists = store.Value.TryGetValue(key, out outVal);
            //    return valueExists ? outVal : null;
            //}
        }

        public static T Get<T>(string key)
        {
            return CommonDataStore.WithDataStore(store).Get<T>(key);
            //lock (store)
            //{
            //    return (T)Get(key);
            //}
        }

        public static void Add(string key, object value)
        {
            CommonDataStore.WithDataStore(store).Add(key, value);
            //lock (store)
            //{
            //    store.Value[key] = value;

            //}
        }

        public static void Clear()
        {
            CommonDataStore.WithDataStore(store).Clear();
            //lock (store)
            //{
            //    store.Value.Clear();
            //}
        }
    }
}