using Ninject;
using Ninject.Modules;
using SKV.DAL.Abstract.Common;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;
using SKV.DAL.Concrete.Model.CallModel;
using SKV.DAL.Concrete.Model.ClientModel;
using SKV.DAL.Concrete.Model.CommonModel;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Concrete.Model.OperationModel;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Concrete.Model.WindowModel;
using SKV.DAL.Tools;
using System;

namespace SKV.DAL
{
    public class DALDependencyResolver 
    {
        private class NInjectBindings : NinjectModule
        {
            public override void Load()
            {
                Bind<DatabaseContext>().ToSelf().InSingletonScope();

                Bind<ISynchronizator>().To<Synchronizator>();

                Bind(typeof(IRepository<Call, int>)).To(typeof(Repository<Call, int>)).InSingletonScope();
                Bind(typeof(IRepository<OperatorPhone, int>)).To(typeof(Repository<OperatorPhone, int>)).InSingletonScope();

                Bind(typeof(IRepository<Client, int>)).To(typeof(Repository<Client, int>)).InSingletonScope();
                Bind(typeof(IRepository<ClientStatus, int>)).To(typeof(Repository<ClientStatus, int>)).InSingletonScope();

                Bind(typeof(IRepository<Page, int>)).To(typeof(Repository<Page, int>)).InSingletonScope();
                Bind(typeof(IRepository<SystemSettings, int>)).To(typeof(Repository<SystemSettings, int>)).InSingletonScope();

                Bind(typeof(IRepository<Currency, int>)).To(typeof(Repository<Currency, int>)).InSingletonScope();
                Bind(typeof(IRepository<CurrencyRate, int>)).To(typeof(Repository<CurrencyRate, int>)).InSingletonScope();
                Bind(typeof(IRepository<CurrencyRateData, int>)).To(typeof(Repository<CurrencyRateData, int>)).InSingletonScope();
                Bind(typeof(IRepository<CurrencyCompetitor, int>)).To(typeof(Repository<CurrencyCompetitor, int>)).InSingletonScope();
                Bind(typeof(IRepository<CurrencyExchangeRule, int>)).To(typeof(Repository<CurrencyExchangeRule, int>)).InSingletonScope();

                Bind(typeof(IRepository<Correction, int>)).To(typeof(Repository<Correction, int>)).InSingletonScope();
                Bind(typeof(IRepository<CorrectionData, int>)).To(typeof(Repository<CorrectionData, int>)).InSingletonScope();

                Bind(typeof(IRepository<Inventarisation, int>)).To(typeof(Repository<Inventarisation, int>)).InSingletonScope();
                Bind(typeof(IRepository<InventarisationData, int>)).To(typeof(Repository<InventarisationData, int>)).InSingletonScope();

                Bind(typeof(IRepository<MoneyTransfer, int>)).To(typeof(Repository<MoneyTransfer, int>)).InSingletonScope();
                Bind(typeof(IRepository<MoneyTransferData, int>)).To(typeof(Repository<MoneyTransferData, int>)).InSingletonScope();

                Bind(typeof(IRepository<Exchange, int>)).To(typeof(Repository<Exchange, int>)).InSingletonScope();
                Bind(typeof(IRepository<ExchangeData, int>)).To(typeof(Repository<ExchangeData, int>)).InSingletonScope();

                Bind(typeof(IRepository<OperationStatus, int>)).To(typeof(Repository<OperationStatus, int>)).InSingletonScope();

                Bind(typeof(IRepository<User, string>)).To(typeof(Repository<User, string>)).InSingletonScope();
                Bind(typeof(IRepository<UserRole, string>)).To(typeof(Repository<UserRole, string>)).InSingletonScope();
                Bind(typeof(IRepository<UserProfile, string>)).To(typeof(Repository<UserProfile, string>)).InSingletonScope();
                Bind(typeof(IRepository<UserPermission, int>)).To(typeof(Repository<UserPermission, int>)).InSingletonScope();

                Bind(typeof(IRepository<Window, int>)).To(typeof(Repository<Window, int>)).InSingletonScope();
                Bind(typeof(IRepository<WindowCash, int>)).To(typeof(Repository<WindowCash, int>)).InSingletonScope();
            }
        }

        public static IKernel Kernel { get; private set; } = new StandardKernel(new NInjectBindings());
    }
}
