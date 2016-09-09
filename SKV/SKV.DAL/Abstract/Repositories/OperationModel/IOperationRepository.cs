using System;
using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Abstract.Repositories.OperationModel
{
    public interface IOperationRepository<TEntity, TKey, TUserKey, TStatusKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : IOperation<TKey, TUserKey, TStatusKey>
    {
        int GetNextDailyNumber();

        IEnumerable<TEntity> GetDataByPeriod(DateTime? start, DateTime? end);

        IEnumerable<TEntity> GetDataByCurrentDay();
    }
}
