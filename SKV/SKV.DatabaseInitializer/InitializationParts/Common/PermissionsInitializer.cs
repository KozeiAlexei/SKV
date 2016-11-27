using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;
using SKV.ML.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DatabaseInitializer.InitializationParts.Common
{
    public class PermissionsInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public PermissionsInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            var perm1 = new UserPermission() { Name = "Показ пункта меню \"Администрирование\"", Code = UserPermissionCode.ShowAdministrationMenuItem };
            var perm2 = new UserPermission() { Name = "Показ пункта меню \"Оператор\"", Code = UserPermissionCode.ShowOperatorMenuItem };

            Context.UserPermissions.Add(perm1);
            Context.UserPermissions.Add(perm2);

            Context.SaveChanges();

            var role = Context.Roles.OfType<UserRole>().Include(e => e.Permissions)
                                    .Where(e => e.DefaultRoleCode == DefaultRole.Admin).First();

            role.Permissions.Add(perm1);
            role.Permissions.Add(perm2);

            Context.SaveChanges();
        }
    }
}
