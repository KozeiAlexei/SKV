using System.ComponentModel.DataAnnotations;

using SKV.ML.Abstract.Model.ClientModel;

namespace SKV.ML.Concrete.Model.ClientModel
{
    /// <summary>
    /// Коды статусов клиента
    /// </summary>
    public enum ClientStatusCode
    {
        /// <summary>
        /// Обычный клиент
        /// </summary>
        Client,

        /// <summary>
        /// VIP-клиент
        /// </summary>
        VIPClient,

        /// <summary>
        /// Неизвестный клиент
        /// </summary>
        UnknownClient,

        /// <summary>
        /// В черном списке
        /// </summary>
        ClientInTheBlackList
    }

    public class ClientStatus : IClientStatus<int, ClientStatusCode>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public ClientStatusCode Code { get; set; }

        public string Description { get; set; }

        public void CopyFrom(IClientStatus<int, ClientStatusCode> from)
        {
            Id = from.Id;
            Name = from.Name;
            Text = from.Text;
            Code = from.Code;
            Description = from.Description;
        }
    }
}
