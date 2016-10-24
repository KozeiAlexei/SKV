using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using SKV.ML.Concrete.Model.CallModel;
using SKV.ML.Concrete.Model.UserModel;
using SKV.ML.Concrete.Model.WindowModel;
using SKV.ML.Concrete.Model.ClientModel;
using SKV.ML.Concrete.Model.CommonModel;
using SKV.ML.Concrete.Model.CurrencyModel;
using SKV.ML.Concrete.Model.OperationModel;

using SKV.ML.Concrete.Model.UIModel;
using SKV.DAL.Concrete.EntityFramework.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SKV.DAL.Concrete.EntityFramework
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        #region Context constructor

#if (DEBUG)
        public DatabaseContext() : base("SKVDB_LOCAL_DEBUG", throwIfV1Schema: false)
#elif (SKV_TEST)
        public DatabaseContext() : base("SKVDB_SERVER_TEST", throwIfV1Schema: false)
#elif (SKV_PRODUCTION)
        public DatabaseContext() : base("SKVDB_SERVER_PRODUCTION", throwIfV1Schema: false)
#endif

        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, MigrationConfiguration>());
        }

        #endregion

        #region CallModel

        public DbSet<Call> Calls { get; set; }

        public DbSet<OperatorPhone> OperatorPhones { get; set; }

        #endregion

        #region ClientModel

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientStatus> ClientStatuses { get; set; }

        #endregion

        #region CommonModel

        public DbSet<Page> Pages { get; set; }

        public DbSet<SystemSettings> SystemSettings { get; set; }

        #endregion

        #region CurrencyModel

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<CurrencyRateData> CurrencyRateData { get; set; }

        public DbSet<CurrencyCompetitor> CurrencyCompetitors { get; set; }

        public DbSet<CurrencyExchangeRule> CurrencyExchangeRules { get; set; }

        #endregion

        #region OperationModel

        public DbSet<Correction> Corrections { get; set; }

        public DbSet<CorrectionData> CorrectionData { get; set; }


        public DbSet<Exchange> Exchanges { get; set; }

        public DbSet<ExchangeData> ExchangeData { get; set; }


        public DbSet<Inventarisation> Inventarisations { get; set; }

        public DbSet<InventarisationData> InventarisationData { get; set; }


        public DbSet<MoneyTransfer> MoneyTrasfer { get; set; }

        public DbSet<MoneyTransferData> MoneyTransferData { get; set; }


        public DbSet<OperationStatus> OperationStatuses { get; set; }

        #endregion

        #region UserModel

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        #endregion

        #region WindowModel

        public DbSet<Window> Windows { get; set; }

        public DbSet<WindowCash> WindowCashes { get; set; }

        #endregion

        #region UIModel

        public DbSet<UICulture> UICulture { get; set; }

        public DbSet<UIMenuItem> UIMenuItems { get; set; }

        public DbSet<UIComponentData> UIComponentData { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder model_builder)
        {
            base.OnModelCreating(model_builder);

            model_builder.Entity<User>().ToTable("IdentityUsers");
            model_builder.Entity<UserRole>().ToTable("IdentityRoles");
            model_builder.Entity<IdentityRole>().ToTable("IdentityRoles");
            model_builder.Entity<IdentityUserRole>().ToTable("IdentityUserRoles");
            model_builder.Entity<IdentityUserLogin>().ToTable("IdentityUserLogins");
            model_builder.Entity<IdentityUserClaim>().ToTable("IdentityUserClaims");

            model_builder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static DatabaseContext Create() => new DatabaseContext();
    }
}
