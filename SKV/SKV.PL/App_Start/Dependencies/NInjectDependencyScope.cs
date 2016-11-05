using System;
using System.Web.Http.Dependencies;

using Ninject;
using Ninject.Syntax;

namespace SKV.PL.App_Start.Dependencies
{
    public class NInjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver = default(IResolutionRoot);

        public NInjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.TryGet(serviceType);
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(Type service_type)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.GetAll(service_type);
        }

        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }
    }
}