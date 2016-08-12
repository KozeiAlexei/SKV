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

namespace SKV.DAL.Abstract.Database
{
    public interface IDbManager: IChangeable
    {
        ICallRepository<Call, int, CallType> Calls { get; }

        IOperatorPhoneRepository<OperatorPhone, int> OperatorPhones { get; }

        
        IClientRepository<Client, int, int, string> Clients { get; }

        IClientStatusRepository<ClientStatus, int, ClientStatusCode> ClientStatuses { get; }


        IPageRepository<Page, int> Pages { get; }

        ISystemSettingsRepository<SystemSettings, int> SystemSettings { get; }

        
        ICurrencyCompetitorRepository<CurrencyCompetitor, int> CurrencyCompetitors { get; }

        ICurrencyExchangeRuleRepository<CurrencyExchangeRule, int, int> CurrencyExchangeRules { get; }

        ICurrencyRateDataRepository<CurrencyRateData, int> CurrencyRateData { get; }

        ICurrencyRateRepository<CurrencyRate, int> CurrencyRates { get; }

        ICurrencyRepository<Currency, int> Currencies { get; }


        ICorrectionRepository<Correction, int, string, int> Corrections { get; }

        ICorrectionDataRepository<CorrectionData, int, int, int, int> CorrectionData { get; }

        IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int> Exchanges { get; }

        IExchangeDataRepository<ExchangeData, int, int, int, int?> ExchangeData { get; }

        IInventarisationRepository<Inventarisation, int, string, int> Inventarisations { get; }

        IInventarisationDataRepository<InventarisationData, int, int, int, int, decimal> InventarisationData { get; }

        IMoneyTransferRepository<MoneyTransfer, int, string, int> MoneyTransfer { get; }

        IMoneyTransferDataRepository<MoneyTransferData, int, int, int?, int?, MoneyTransferBase> MoneyTransferData { get; }

        IOperationStatusRepository<OperationStatus, int, OperationType, int> OperationStatuses { get; }

        
        IUserPermissionRepository<UserPermission, int, UserPermissionCode> UserPermissions { get; }

        IUserProfileRepository<UserProfile, string> UserProfiles { get; }

        IUserRepository<User, string> Users { get; }

        IUserRoleRepository<UserRole, string, DefaultRole> UserRoles { get; }

        
        IWindowRepository<Window, int, WindowStatus> Windows { get; }

        IWindowCashRepository<WindowCash, int, int, int> WindowCashes { get; }
    }
}
