using Newtonsoft.Json;
using Ninject;
using SKV.DAL;
using SKV.DAL.Abstract.Repositories.UIModel;
using SKV.ML.Concrete;
using SKV.ML.Concrete.Model.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.BLL.Other
{
    public class CacheObject
    {
        static CacheObject()
        {
            Cache.Add(CacheItemClass.UI, new Dictionary<int, object>());
        }

        private static object sync_context = new object();
        private static Dictionary<CacheItemClass, Dictionary<int, object>> Cache { get; } = new Dictionary<CacheItemClass, Dictionary<int, object>>();

        public static TCacheItem Get<TCacheItem>(CacheItemClass @class, int key)
        {
            var @object = default(object); ++key;
            lock(sync_context)
            {
                var level0_cache = default(Dictionary<int, object>);
                Cache.TryGetValue(@class, out level0_cache);

                level0_cache.TryGetValue(key, out @object);
            }

            var deserialized = default(object);
            if (@object == null)
            {
                if (@class == CacheItemClass.UI)
                {
                    var repository = (IUIComponentDataRepository<UIComponentData, int, string>)DALDependencyResolver.Kernel.Get(typeof(IUIComponentDataRepository<UIComponentData, int, string>));
                    @object = repository.GetUIComponentDataById(key);

                    deserialized = JsonConvert.DeserializeObject(((UIComponentData)@object).SerializedData);

                    Set(CacheItemClass.UI, key, deserialized);
                }
            }
            else
                return (TCacheItem)@object;

            return (TCacheItem)deserialized;
        }

        public static void Set<TCacheItem>(CacheItemClass @class, int key, TCacheItem @object)
        {
            lock(sync_context)
            {
                var level0_cache = default(Dictionary<int, object>);
                Cache.TryGetValue(@class, out level0_cache);

                level0_cache.Add(key, @object);
            }
        }
    }
}