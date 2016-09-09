using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.ClientModel
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
