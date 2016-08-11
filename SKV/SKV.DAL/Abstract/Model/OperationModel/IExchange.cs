using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IExchange<TKey, TExchangeSource, TUserKey, TClientKey, TWindowKey, TStatusKey> 
        : IOperation<TKey, TUserKey, TStatusKey>, ICloneableFrom<IExchange<TKey, TExchangeSource, TUserKey, TClientKey, TWindowKey, TStatusKey>>
    {
        string Comment { get; set; }

        DateTime ExpirationDate { get; set; }

        TClientKey ClientId { get; set; }

        TWindowKey WindowId { get; set; }

        TExchangeSource Source { get; set; }

    }
}
