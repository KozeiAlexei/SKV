using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.EntityFramework;

using SKV.DAL.Abstract.Repositories.CallModel;
using SKV.DAL.Abstract.Repositories.UserModel;
using SKV.DAL.Abstract.Repositories.WindowModel;
using SKV.DAL.Abstract.Repositories.ClientModel;
using SKV.DAL.Abstract.Repositories.CommonModel;
using SKV.DAL.Abstract.Repositories.CurrencyModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

using SKV.DAL.Concrete.Model.CallModel;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Concrete.Model.WindowModel;
using SKV.DAL.Concrete.Model.ClientModel;
using SKV.DAL.Concrete.Model.CommonModel;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.UIModel;
using SKV.DAL.Concrete.Model.UIModel;

namespace SKV.DAL.Concrete.Database
{
    public class DbManager : IDbManager
    {
        private DatabaseContext context = DALDependencyResolver.Kernel.Get<DatabaseContext>();


        public ICallRepository<Call, int, CallType> Calls { get; } =
            (ICallRepository<Call, int, CallType>)DALDependencyResolver.Kernel.Get(typeof(ICallRepository<Call, int, CallType>));

        public IClientRepository<Client, int, int, string> Clients { get; } =
            (IClientRepository<Client, int, int, string>)DALDependencyResolver.Kernel.Get(typeof(IClientRepository<Client, int, int, string>));

        public IClientStatusRepository<ClientStatus, int, ClientStatusCode> ClientStatuses { get; } =
            (IClientStatusRepository<ClientStatus, int, ClientStatusCode>)DALDependencyResolver.Kernel.Get(typeof(IClientStatusRepository<ClientStatus, int, ClientStatusCode>));

        public ICorrectionDataRepository<CorrectionData, int, int, int, int> CorrectionData { get; } =
            (ICorrectionDataRepository<CorrectionData, int, int, int, int>)DALDependencyResolver.Kernel.Get(typeof(ICorrectionDataRepository<CorrectionData, int, int, int, int>));

        public ICorrectionRepository<Correction, int, string, int> Corrections { get; } =
            (ICorrectionRepository<Correction, int, string, int>)DALDependencyResolver.Kernel.Get(typeof(ICorrectionRepository<Correction, int, string, int>));

        public ICurrencyRepository<Currency, int> Currencies { get; } =
            (ICurrencyRepository<Currency, int>)DALDependencyResolver.Kernel.Get(typeof(ICurrencyRepository<Currency, int>));

        public ICurrencyCompetitorRepository<CurrencyCompetitor, int> CurrencyCompetitors { get; } =
            (ICurrencyCompetitorRepository<CurrencyCompetitor, int>)DALDependencyResolver.Kernel.Get(typeof(ICurrencyCompetitorRepository<CurrencyCompetitor, int>));

        public ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int> CurrencyExchangeRules { get; } =
            (ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int>)DALDependencyResolver.Kernel.Get(typeof(ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int>));

        public ICurrencyRateDataRepository<CurrencyRateData, int> CurrencyRateData { get; } =
            (ICurrencyRateDataRepository<CurrencyRateData, int>)DALDependencyResolver.Kernel.Get(typeof(ICurrencyRateDataRepository<CurrencyRateData, int>));

        public ICurrencyRateRepository<CurrencyRate, int> CurrencyRates { get; } =
            (ICurrencyRateRepository<CurrencyRate, int>)DALDependencyResolver.Kernel.Get(typeof(ICurrencyRateRepository<CurrencyRate, int>));

        public IExchangeDataRepository<ExchangeData, int, int, int?, int?> ExchangeData { get; } =
            (IExchangeDataRepository<ExchangeData, int, int, int?, int?>)DALDependencyResolver.Kernel.Get(typeof(IExchangeDataRepository<ExchangeData, int, int, int?, int?>));

        public IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int> Exchanges { get; } =
            (IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int>)DALDependencyResolver.Kernel.Get(typeof(IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int>));

        public IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal> InventarisationData { get; } =
            (IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal>)DALDependencyResolver.Kernel.Get(typeof(IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal>));

        public IInventarisationRepository<Inventarisation, int, string, int> Inventarisations { get; } =
            (IInventarisationRepository<Inventarisation, int, string, int>)DALDependencyResolver.Kernel.Get(typeof(IInventarisationRepository<Inventarisation, int, string, int>));

        public IMoneyTransferRepository<MoneyTransfer, int, string, int> MoneyTransfer { get; } =
            (IMoneyTransferRepository<MoneyTransfer, int, string, int>)DALDependencyResolver.Kernel.Get(typeof(IMoneyTransferRepository<MoneyTransfer, int, string, int>));

        public IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase> MoneyTransferData { get; } =
            (IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase>)DALDependencyResolver.Kernel.Get(typeof(IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase>));

        public IOperationStatusRepository<OperationStatus, int, OperationType, int> OperationStatuses { get; } =
            (IOperationStatusRepository<OperationStatus, int, OperationType, int>)DALDependencyResolver.Kernel.Get(typeof(IOperationStatusRepository<OperationStatus, int, OperationType, int>));

        public IOperatorPhoneRepository<OperatorPhone, int> OperatorPhones { get; } =
            (IOperatorPhoneRepository<OperatorPhone, int>)DALDependencyResolver.Kernel.Get(typeof(IOperatorPhoneRepository<OperatorPhone, int>));

        public IPageRepository<Page, int> Pages { get; } =
            (IPageRepository<Page, int>)DALDependencyResolver.Kernel.Get(typeof(IPageRepository<Page, int>));

        public ISystemSettingsRepository<SystemSettings, int, int> SystemSettings { get; } =
            (ISystemSettingsRepository<SystemSettings, int, int>)DALDependencyResolver.Kernel.Get(typeof(ISystemSettingsRepository<SystemSettings, int, int>));

        public IUserPermissionRepository<UserPermission, int, UserPermissionCode> UserPermissions { get; } =
            (IUserPermissionRepository<UserPermission, int, UserPermissionCode>)DALDependencyResolver.Kernel.Get(typeof(IUserPermissionRepository<UserPermission, int, UserPermissionCode>));

        public IUserProfileRepository<UserProfile, string> UserProfiles { get; } =
            (IUserProfileRepository<UserProfile, string>)DALDependencyResolver.Kernel.Get(typeof(IUserProfileRepository<UserProfile, string>));

        public IUserRoleRepository<UserRole, string, DefaultRole> UserRoles { get; } =
            (IUserRoleRepository<UserRole, string, DefaultRole>)DALDependencyResolver.Kernel.Get(typeof(IUserRoleRepository<UserRole, string, DefaultRole>));

        public IUserRepository<User, string> Users { get; } =
            (IUserRepository<User, string>)DALDependencyResolver.Kernel.Get(typeof(IUserRepository<User, string>));

        public IWindowCashRepository<WindowCash, int, int, int> WindowCashes { get; } =
            (IWindowCashRepository<WindowCash, int, int, int>)DALDependencyResolver.Kernel.Get(typeof(IWindowCashRepository<WindowCash, int, int, int>));

        public IWindowRepository<Window, int, WindowStatus> Windows { get; } =
            (IWindowRepository<Window, int, WindowStatus>)DALDependencyResolver.Kernel.Get(typeof(IWindowRepository<Window, int, WindowStatus>));


        public IUICultureRepository<UICulture, int> UICultures { get; } =
            (IUICultureRepository<UICulture, int>)DALDependencyResolver.Kernel.Get(typeof(IUICultureRepository<UICulture, int>));

        public IUIMenuItemRepository<UIMenuItem, int, int?> UIMenuItems { get; } =
            (IUIMenuItemRepository<UIMenuItem, int, int?>)DALDependencyResolver.Kernel.Get(typeof(IUIMenuItemRepository<UIMenuItem, int, int?>));

        public void Refresh()
        {
            var object_context = ((IObjectContextAdapter)context).ObjectContext;

            var state = EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged;

            var object_collection = object_context.ObjectStateManager.GetObjectStateEntries(state)
                                                                     .Where(e => e.EntityKey != null)
                                                                     .Select(e => e.Entity);

            object_context.Refresh(RefreshMode.StoreWins, object_collection);
        }

        public void SaveChanges() => context.SaveChanges();
    }
}