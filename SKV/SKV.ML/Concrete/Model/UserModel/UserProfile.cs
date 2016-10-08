using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.ML.Abstract.Model.UserModel;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SKV.ML.Concrete.Model.UserModel
{
    public class UserProfile : IUserProfile<string>
    {
        [Key]
        [ForeignKey("UserInstance")]
        public string Id { get; set; }

        [JsonIgnore]
        public virtual User UserInstance { get; set; }

        [Required]
        public string Name { get; set; }

        public int? AsteriskId { get; set; }


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
