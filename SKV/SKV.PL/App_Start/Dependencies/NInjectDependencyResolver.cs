using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SKV.PL.App_Start.Dependencies
{
    public class NInjectDependencyResolver : NInjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel = default(IKernel);

        public NInjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NInjectDependencyScope(kernel.BeginBlock());
        }
    }
}