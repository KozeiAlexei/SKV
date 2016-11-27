using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;
using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DatabaseInitializer.InitializationParts.Common
{
    public class UsersInitializer : IEntityInitializer
    {
        public DatabaseContext Context { get; set; }

        public UsersInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            var user_manager = new UserManager<User>(new UserStore<User>(Context));
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
        }
    }
}
