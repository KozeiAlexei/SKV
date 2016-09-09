using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.CallModel
{
    public interface IOperatorPhone<TKey> : IEntity<TKey>, ICloneableFrom<IOperatorPhone<TKey>>
    {
        string PhoneNumber { get; set; }
    }
}
