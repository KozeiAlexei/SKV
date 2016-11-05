using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNet.Identity.EntityFramework;

using SKV.ML.Abstract.Model.UserModel;
using SKV.ML.Concrete.Model.CommonModel;

namespace SKV.ML.Concrete.Model.UserModel
{
    public enum DefaultRole
    {
        Admin,

        Lead,
        Manager,
        Cashier,

        Custom
    }

    public class UserRole : IdentityRole, IUserRole<string, DefaultRole>
    {
        public int DefaultPageId { get; set; }

        [ForeignKey(nameof(DefaultPageId))]
        public Page PageInstance { get; set; }

        public DefaultRole DefaultRoleCode { get; set; }


        public List<UserPermission> Permissions { get; set; }

        public void CopyFrom(IUserRole<string, DefaultRole> from)
        {
            Id = from.Id;
            Name = from.Name;
            DefaultPageId = from.DefaultPageId;
            DefaultRoleCode = from.DefaultRoleCode;
        }
    }
}
