using System;

using Ninject;
using Ninject.Parameters;

using SKV.PL.ClientSide.Abstract;
using System.Linq;
using System.Linq.Expressions;

namespace SKV.PL.ClientSide.Concrete
{
    public class Tools
    {
        public static IResponsibilityChain<TSubject> CreateResponsibilityChain<TSubject>(TSubject obj) =>
            (IResponsibilityChain<TSubject>)PLDependencyResolver.Kernel.Get(typeof(IResponsibilityChain<TSubject>), new ConstructorArgument("obj", obj));


        public static IContainer CreateContainer() => PLDependencyResolver.Kernel.Get<IContainer>();

        public static void ThrowIfCondition(string field_name, Func<bool> condition)
        {
            var @res = false;
            try
            {
                @res = condition();
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Component parameter(s) \"{ field_name }\" has wrong value!", ex);
            }
            
            if(res)
                throw new ArgumentException($"Component parameter(s) \"{ field_name }\" has wrong value!");
        }

        public static void ThrowIfNull<T>(T obj, string field_name) => ThrowIfCondition(field_name, () => obj == null);

        public static string GetLocalizedString(string key) => Resources.Resource.ResourceManager.GetString(key);

        public static TCustomAttribute GetAttribute<TCustomAttribute, TModel>(TModel model) where TCustomAttribute: Attribute => 
            (TCustomAttribute)typeof(TModel).GetCustomAttributes(typeof(TCustomAttribute), true).FirstOrDefault();
    }
}