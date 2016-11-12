[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SKV.PL.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(SKV.PL.App_Start.NinjectWebCommon), "Stop")]

namespace SKV.PL.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using BLL.Identity;
    using BLL.Abstract.Identity;

    using ML.Concrete.Model.UserModel;
    using ML.ViewModels.Account;
    using Microsoft.AspNet.Identity.Owin;
    using BLL.Abstract.UI;
    using BLL.UI;

    public static class NinjectWebCommon 
    {
        public static Bootstrapper Bootstrapper { get; } = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            Bootstrapper.Initialize(CreateKernel);

        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUICultureManager>().To<UICultureManager>();
            kernel.Bind<IUIMenuItemManager>().To<UIMenuItemManager>();

            kernel.Bind(typeof(IIdentityRoleManager<UserRole>)).To<IdentityRoleManager>();
            kernel.Bind(typeof(IIdentityPermissionManager<UserPermission>)).To<IdentityPermissionManager>();

            kernel.Bind(typeof(IIdentityUserManager<User, UserCreatingViewModel>)).ToMethod(m => 
                new HttpContextWrapper(HttpContext.Current).GetOwinContext().GetUserManager<IdentityUserManager>());
        }        
    }
}
