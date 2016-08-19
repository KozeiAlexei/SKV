using Ninject;
using Ninject.Modules;

using SKV.BLL.CurrencyRates;
using SKV.BLL.Abstract.CurrencyRates;

namespace SKV.BLL
{
    public class BLLDependencyResolver
    {
        private class NInjectBindings : NinjectModule
        {
            public override void Load()
            {
                Bind<IForexParser>().To<ForexParser>();
                Bind<IRatesProvider>().To<ForexRatesProvider>();
            }
        }

        public static IKernel Kernel { get; } = new StandardKernel(new NInjectBindings());
    }
}
