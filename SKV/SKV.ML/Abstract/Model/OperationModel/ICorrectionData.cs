using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface ICorrectionData<TKey, TCorrectionKey, TWindowKey, TCurrencyKey> 
        : IEntity<TKey>, ICloneableFrom<ICorrectionData<TKey, TCorrectionKey, TWindowKey, TCurrencyKey>>
    {
        TWindowKey WindowId { get; set; }

        TCurrencyKey CurrencyId { get; set; }

        TCorrectionKey CorrectionId { get; set; }


        decimal Sum { get; set; }
    }
}
