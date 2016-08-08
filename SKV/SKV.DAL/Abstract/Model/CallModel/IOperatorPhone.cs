using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CallModel
{
    public interface IOperatorPhone<TKey> : IEntity<TKey>, ICloneableFrom<IOperatorPhone<TKey>>
    {
        string PhoneNumber { get; set; }
    }
}
