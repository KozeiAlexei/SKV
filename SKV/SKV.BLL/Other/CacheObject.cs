using System;
using System.Collections.Generic;

using Ninject;
using Newtonsoft.Json;

using SKV.DAL;
using SKV.DAL.Abstract.Repositories.UIModel;

using SKV.ML.Concrete;
using SKV.ML.Concrete.Model.UIModel;

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
                var cache_type = default(Dictionary<int, object>);
                Cache.TryGetValue(@class, out cache_type);

                cache_type.TryGetValue(key, out @object);
            }

            var deserialized = default(object);
            if (@object == null)
            {
                if (@class == CacheItemClass.UI)
                {
                    var repository = (IUIComponentDataRepository<UIComponentData, int, string>)DALDependencyResolver.Kernel.Get(typeof(IUIComponentDataRepository<UIComponentData, int, string>));
                    @object = repository.GetUIComponentDataById(key);

                    deserialized = JsonConvert.DeserializeObject(((UIComponentData)@object).SerializedData, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

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
                var cache_type = default(Dictionary<int, object>);
                Cache.TryGetValue(@class, out cache_type);

                cache_type.Add(key, @object);
            }
        }
    }
}