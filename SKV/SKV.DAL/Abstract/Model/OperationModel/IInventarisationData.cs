using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IInventarisationData<TKey, TInventarisationKey, TWindowKey, TCurrencyKey, TResult> :
        IEntity<TKey>, ICloneableFrom<IInventarisationData<TKey, TInventarisationKey, TWindowKey, TCurrencyKey, TResult>>
    {
        TWindowKey WindowId { get; set; }

        TCurrencyKey CurrencyId { get; set; }

        TInventarisationKey InventarisationId { get; set; }

        float? FactSum { get; set; }

        float? SystemSum { get; set; }

        TResult Result { get; set; }
    }
}
