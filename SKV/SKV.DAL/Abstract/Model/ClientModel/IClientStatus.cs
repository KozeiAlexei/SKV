using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.ClientModel
{
    public interface IClientStatus<TKey, TStatus> : IEntity<TKey>, ICloneableFrom<IClientStatus<TKey, TStatus>>
        where TStatus : struct
    {
        string Name { get; set; }

        string Text { get; set; }

        string Description { get; set; }


        TStatus Code { get; set; }
    }
}
