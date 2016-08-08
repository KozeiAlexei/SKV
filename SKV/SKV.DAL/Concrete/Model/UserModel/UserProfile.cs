using SKV.DAL.Abstract.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.UserModel
{
    public class UserProfile : IUserProfile<string>
    {
        [Key]
        [ForeignKey("UserInstance")]
        public string Id { get; set; }

        public virtual User UserInstance { get; set; }

        public string Name { get; set; }


        public DateTime LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public void CopyFrom(IUserProfile<string> from)
        {
            Id = from.Id;
            Name = from.Name;

            LastLoginDate = from.LastLoginDate;
            RegistrationDate = from.RegistrationDate;
        }
    }
}
