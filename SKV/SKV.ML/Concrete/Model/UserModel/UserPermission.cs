using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.UserModel;

namespace SKV.ML.Concrete.Model.UserModel
{
    public enum UserPermissionCode
    {

    }

    public class UserPermission : IUserPermission<int, UserPermissionCode>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public UserPermissionCode Code { get; set; }


        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public void CopyFrom(IUserPermission<int, UserPermissionCode> from)
        {
            Id = from.Id;
            Name = from.Name;
            Code = from.Code;
        }
    }
}
