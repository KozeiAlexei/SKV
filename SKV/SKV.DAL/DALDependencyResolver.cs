using Ninject;
using Ninject.Modules;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Common;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;
using SKV.ML.Concrete.Model.UIModel;
using SKV.ML.Concrete.Model.CallModel;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.Concrete.Model.WindowModel;
using SKV.ML.Concrete.Model.ClientModel;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.ML.Concrete.Model.CurrencyModel;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Concrete.Database;
using SKV.DAL.Abstract.Repositories.CallModel;
using SKV.DAL.Concrete.Repositories.CallModel;
using SKV.DAL.Abstract.Repositories.ClientModel;
using SKV.DAL.Concrete.Repositories.ClientModel;
using SKV.DAL.Abstract.Repositories.CommonModel;
using SKV.DAL.Concrete.Repositories.CommonModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;
using SKV.DAL.Concrete.Repositories.CurrencyModel;
using SKV.DAL.Abstract.Repositories.OperationModel;
using SKV.DAL.Concrete.Repositories.OperationModel;
using SKV.DAL.Abstract.Repositories.UIModel;
using SKV.DAL.Concrete.Repositories.UIModel;
using SKV.DAL.Abstract.Repositories.UserModel;
using SKV.DAL.Concrete.Repositories.UserModel;
using SKV.DAL.Abstract.Repositories.WindowModel;
using SKV.DAL.Concrete.Repositories.WindowModel;

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

                Bind(typeof(IRepository<UICulture, int>)).To(typeof(Repository<UICulture, int>)).InSingletonScope();
                Bind(typeof(IRepository<UIMenuItem, int>)).To(typeof(Repository<UIMenuItem, int>)).InSingletonScope();
                Bind(typeof(IRepository<UIComponentData, int>)).To(typeof(Repository<UIComponentData, int>)).InSingletonScope();

                Bind(typeof(ICallRepository<Call, int, CallType>)).To<CallRepository>();
                Bind(typeof(IOperatorPhoneRepository<OperatorPhone, int>)).To<OperatorPhoneRepository>();

                Bind(typeof(IClientRepository<Client, int, int, string>)).To<ClientRepository>();
                Bind(typeof(IClientStatusRepository<ClientStatus, int, ClientStatusCode>)).To<ClientStatusRepository>();

                Bind(typeof(IPageRepository<Page, int>)).To<PageRepository>();
                Bind(typeof(ISystemSettingsRepository<SystemSettings, int, int>)).To<SystemSettingsRepository>();

                Bind(typeof(ICurrencyRepository<Currency, int>)).To<CurrencyRepository>();
                Bind(typeof(ICurrencyRateRepository<CurrencyRate, int>)).To<CurrencyRateRepository>();
                Bind(typeof(ICurrencyRateDataRepository<CurrencyRateData, int>)).To<CurrencyRateDataRepository>();
                Bind(typeof(ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int>)).To<CurrencyExchangeRuleRepository>();
                Bind(typeof(ICurrencyCompetitorRepository<CurrencyCompetitor, int>)).To<CurrencyCompetitorRepository>();

                Bind(typeof(ICorrectionRepository<Correction, int, string, int>)).To<CorrectionRepository>();
                Bind(typeof(ICorrectionDataRepository<CorrectionData, int, int, int, int>)).To<CorrectionDataRepository>();
                Bind(typeof(IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int>)).To<ExchangeRepository>();
                Bind(typeof(IExchangeDataRepository<ExchangeData, int, int, int?, int?>)).To<ExchangeDataRepository>();
                Bind(typeof(IInventarisationRepository<Inventarisation, int, string, int>)).To<InventarisationRepository>();
                Bind(typeof(IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal>)).To<InventarisationDataRepository>();
                Bind(typeof(IMoneyTransferRepository<MoneyTransfer, int, string, int>)).To<MoneyTransferRepository>();
                Bind(typeof(IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase>)).To<MoneyTransferDataRepository>();
                Bind(typeof(IOperationStatusRepository<OperationStatus, int, OperationType, int>)).To<OperationStatusRepository>();

                Bind(typeof(IUICultureRepository<UICulture, int>)).To<UICultureRepository>();
                Bind(typeof(IUIMenuItemRepository<UIMenuItem, int, int?>)).To<UIMenuItemRepository>();
                Bind(typeof(IUIComponentDataRepository<UIComponentData, int, string>)).To<UIComponentDataRepository>();

                Bind(typeof(IUserRepository<User, string>)).To<UserRepository>();
                Bind(typeof(IUserRoleRepository<UserRole, string, DefaultRole>)).To<UserRoleRepository>();
                Bind(typeof(IUserProfileRepository<UserProfile, string>)).To<UserProfileRepository>();
                Bind(typeof(IUserPermissionRepository<UserPermission, int, UserPermissionCode>)).To<UserPermissionRepository>();

                Bind(typeof(IWindowRepository<Window, int, WindowStatus>)).To<WindowRepository>();
                Bind(typeof(IWindowCashRepository<WindowCash, int, int, int>)).To<WindowCashRepository>();

                Bind<IDbManager>().To<DbManager>();
            }
        }

        public static IKernel Kernel { get; private set; } = new StandardKernel(new NInjectBindings());
    }
}
