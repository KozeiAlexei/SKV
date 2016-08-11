using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SKV.DAL.Abstract.Model.ClientModel;

namespace SKV.DAL.Concrete.Model.ClientModel
{
    public class Client : IClient<int, int, string>
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public ClientStatus StatusInstance { get; set; }

        public void CopyFrom(IClient<int, int, string> from)
        {
            Id = from.Id;
            Code = from.Code;
            Name = from.Name;
            Phone = from.Phone;
            RegistrationDate = from.RegistrationDate;

            StatusId = from.StatusId;
        }
    }
}
