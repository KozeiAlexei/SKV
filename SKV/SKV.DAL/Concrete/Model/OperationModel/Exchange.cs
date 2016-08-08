using SKV.DAL.Abstract.Model.OperationModel;
using SKV.DAL.Concrete.Model.ClientModel;
using SKV.DAL.Concrete.Model.WindowModel;
using SKV.DAL.Concrete.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Concrete.Model.OperationModel
{
    /// <summary>
    /// Источник операции обмена
    /// </summary>
    public enum ExchangeSource
    {
        /// <summary>
        /// Телефон
        /// </summary>
        Phone,

        /// <summary>
        /// Клиент явился лично
        /// </summary>
        Personal,

        /// <summary>
        /// Интернет
        /// </summary>
        Internet
    }


    public class Exchange : IExchange<int, ExchangeSource, string, int, int, int>
    {
        [Key]
        public int Id { get; set; }

        public int DailyNumber { get; set; }


        public DateTime Date { get; set; }

        public DateTime ExpirationDate { get; set; }


        public string Comment { get; set; }

        public ExchangeSource Source { get; set; }


        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client ClientInstance { get; set; }


        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public OperationStatus StatusInstance { get; set; }


        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User UserInstance { get; set; }


        public int WindowId { get; set; }

        [ForeignKey(nameof(WindowId))]
        public Window WindowInstance { get; set; }

        public List<ExchangeData> ExchangeData { get; set; } = new List<ExchangeData>();

        public void CopyFrom(IExchange<int, ExchangeSource, string, int, int, int> from)
        {
            throw new NotImplementedException();
        }
    }
}
