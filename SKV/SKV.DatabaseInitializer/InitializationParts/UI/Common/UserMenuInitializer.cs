using SKV.ML.Concrete.Model.UIModel;
using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;

namespace SKV.DatabaseInitializer.InitializationParts.UI.Common
{
    public class UserMenuInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public UserMenuInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 1, Location = 1, ParentId = null, Name = "Administration", IconClass = "icon-home-3" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 2, Location = 2, ParentId = null, Name = "Operator", IconClass = "icon-home-3" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 3, Location = 3, ParentId = null, Name = "Reports", IconClass = "icon-home-3" });

            Context.UIMenuItems.Add(new UIMenuItem() { Id = 4, Location = 1, ParentId = 1, Name = "SystemSettings" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 5, Location = 2, ParentId = 1, Name = "MenuSettings" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 6, Location = 3, ParentId = 1, Name = "EventJournal" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 7, Location = 4, ParentId = 1, Name = "RoleManager", Controller = "Administration/Security/RoleManager", Action = "Index" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 8, Location = 5, ParentId = 1, Name = "UserManager", Controller = "Administration/Security/UserManager", Action = "Index" });

            Context.UIMenuItems.Add(new UIMenuItem() { Id = 9, Location = 1, ParentId = 2, Name = "MonitoringSystem" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 10, Location = 2, ParentId = 2, Name = "Exchange" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 11, Location = 3, ParentId = 2, Name = "Correction" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 12, Location = 4, ParentId = 2, Name = "Inventarisation" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 13, Location = 5, ParentId = 2, Name = "MoneyTransfer" });

            Context.UIMenuItems.Add(new UIMenuItem() { Id = 14, Location = 1, ParentId = 3, Name = "CashRemainsReport" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 15, Location = 2, ParentId = 3, Name = "InventarisationReport" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 16, Location = 3, ParentId = 3, Name = "ProfitReport" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 17, Location = 3, ParentId = 3, Name = "DealReport" });
            Context.UIMenuItems.Add(new UIMenuItem() { Id = 18, Location = 3, ParentId = 3, Name = "CanceledOrdersReport" });

            Context.SaveChanges();
        }
    }
}
