using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.WindowModel
{
    public interface IWindowCash<TKey, TWindowKey, TCurrencyKey> : IEntity<TKey>, ICloneableFrom<IWindowCash<TKey, TWindowKey, TCurrencyKey>>
    {
        TWindowKey WindowId { get; set; }

        TCurrencyKey CurrencyId { get; set; }

        decimal Sum { get; set; }
    }
}
