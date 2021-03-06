﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SKV.BLL.Identity;
using SKV.DAL;
using SKV.DAL.Concrete.EntityFramework;
using SKV.DAL.Concrete.Model.CommonModel;
using SKV.DAL.Concrete.Model.UIModel;
using SKV.DAL.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DatabaseInitializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseContext();

            db.UICultures.Add(new UICulture() { Name = "Русский", Culture = "ru-RU" });
            db.UICultures.Add(new UICulture() { Name = "English", Culture = "en-US" });

          

            db.UIMenuItems.Add(new UIMenuItem() { Id = 1, Location = 1, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Administration", IconClass = "icon-home-3" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 2, Location = 2, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Operator", IconClass = "icon-home-3" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 3, Location = 3, ParentId = DALStaticData.UIMenuItemTopParentId, Name = "Reports", IconClass = "icon-home-3" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 4, Location = 1, ParentId = 1, Name = "SystemSettings" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 5, Location = 2, ParentId = 1, Name = "MenuSettings" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 6, Location = 3, ParentId = 1, Name = "EventJournal" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 7, Location = 4, ParentId = 1, Name = "RoleManager" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 8, Location = 5, ParentId = 1, Name = "UserManager" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 9, Location = 1, ParentId = 2, Name = "MonitoringSystem" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 10, Location = 2, ParentId = 2, Name = "Exchange" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 11, Location = 3, ParentId = 2, Name = "Correction" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 12, Location = 4, ParentId = 2, Name = "Inventarisation" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 13, Location = 5, ParentId = 2, Name = "MoneyTransfer" });

            db.UIMenuItems.Add(new UIMenuItem() { Id = 14, Location = 1, ParentId = 3, Name = "CashRemainsReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 15, Location = 2, ParentId = 3, Name = "InventarisationReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 16, Location = 3, ParentId = 3, Name = "ProfitReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 17, Location = 3, ParentId = 3, Name = "DealReport" });
            db.UIMenuItems.Add(new UIMenuItem() { Id = 18, Location = 3, ParentId = 3, Name = "CanceledOrdersReport" });


            db.SaveChanges();

            db.SystemSettings.Add(new SystemSettings()
            {
                DefaultCultureId = 1
            });

            db.SaveChanges();

            var user_manager = new UserManager<User>(new UserStore<User>(db));
            var user = new User()
            {
                Email = string.Empty,
                UserName = "Admin",
                Profile = new UserProfile()
                {
                    Name = "Администратор",
                    LastLoginDate = DateTime.Now,
                    RegistrationDate = DateTime.Now,
                }
            };


            var result = user_manager.CreateAsync(user, "Evolution1_").Result;

            db.Dispose();
        }
    }
}
