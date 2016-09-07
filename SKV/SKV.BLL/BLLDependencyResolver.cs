using Ninject;
using Ninject.Modules;

using SKV.BLL.CurrencyRates;
using SKV.BLL.Abstract.CurrencyRates;
using SKV.BLL.Abstract.UI;
using SKV.BLL.UI;

namespace SKV.BLL
{
    public class BLLDependencyResolver
    {
        private class NInjectBindings : NinjectModule
        {
            public override void Load()
            {
                Bind<IForexParser>().To<ForexParser>();
                Bind<ICurrencyRateManager>().To<CurrencyRateManager>();

                Bind<IUICultureManager>().To<UICultureManager>();
                Bind<IUIMenuItemManager>().To<UIMenuItemManager>();

            }
        }

        public static IKernel Kernel { get; } = new StandardKernel(new NInjectBindings());
    }
}
