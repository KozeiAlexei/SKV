using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.WindowModel
{
    public interface IWindowCash<TKey, TWindowKey, TCurrencyKey> : IEntity<TKey>, ICloneableFrom<IWindowCash<TKey, TWindowKey, TCurrencyKey>>
    {
        TWindowKey WindowId { get; set; }

        TCurrencyKey CurrencyId { get; set; }

        decimal Sum { get; set; }
    }
}
