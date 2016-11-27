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
    public class RolesInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public RolesInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            var role_manager = new RoleManager<UserRole>(new RoleStore<UserRole>(Context));
            var role = new UserRole()
            {
                DefaultRoleCode = DefaultRole.Admin,
                DefaultPageId = 1,
                Name = "Admin",
            };
            var role_result = role_manager.Create(role);
        }
    }
}
