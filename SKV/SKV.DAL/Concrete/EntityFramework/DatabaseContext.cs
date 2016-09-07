using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using SKV.DAL.Concrete.Model.CallModel;
using SKV.DAL.Concrete.Model.UserModel;
using SKV.DAL.Concrete.Model.WindowModel;
using SKV.DAL.Concrete.Model.ClientModel;
using SKV.DAL.Concrete.Model.CommonModel;
using SKV.DAL.Concrete.Model.CurrencyModel;
using SKV.DAL.Concrete.Model.OperationModel;

using SKV.DAL.Concrete.Model.UIModel;

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

        public DbSet<UICulture> UICultures { get; set; }

        public DbSet<UIMenuItem> UIMenuItems { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("IdentityUsers");
            modelBuilder.Entity<UserRole>().ToTable("IdentityRoles");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("IdentityUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IdentityUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IdentityUserClaims");
        }

        public static DatabaseContext Create() => new DatabaseContext();
    }
}
