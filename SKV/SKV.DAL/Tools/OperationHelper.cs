using System;
using System.Linq;
using System.Collections.Generic;

using SKV.DAL.Abstract.Database;
using SKV.ML.Abstract.Model.OperationModel;

namespace SKV.DAL.Tools
{
    public static class OperationHelper
    {
        private const int INITIAL_DAILY_NUMBER = 1;

        public static int GetNextDailyNumber<TEntity, TKey, TUserKey, TStatusKey>(IRepository<TEntity, TKey> repo)
            where TEntity : IOperation<TKey, TUserKey, TStatusKey>
        {
            var current_day_data = GetDataByCurrentDay<TEntity, TKey, TUserKey, TStatusKey>(repo);
            if (current_day_data.Any())
                return current_day_data.Last().DailyNumber + 1;
            else
                return INITIAL_DAILY_NUMBER;
        }

        public static IEnumerable<TEntity> GetDataByPeriod<TEntity, TKey, TUserKey, TStatusKey>(IRepository<TEntity, TKey> repo, DateTime? start, DateTime? end)
            where TEntity : IOperation<TKey, TUserKey, TStatusKey>
        {
            var query = default(Func<IEnumerable<TEntity>>);
            if (start.HasValue && end.HasValue)
                query = () => repo.Table.Where(e => e.Date <= end.Value && e.Date >= start);
            else if (start.HasValue && !end.HasValue)
                query = () => repo.Table.Where(e => e.Date >= start);
            else if (!start.HasValue && end.HasValue)
                query = () => repo.Table.Where(e => e.Date <= end.Value);
            else
                query = () => repo.Table.AsEnumerable();

            return repo.Sync.Synchronize(query);
        }

        public static IEnumerable<TEntity> GetDataByCurrentDay<TEntity, TKey, TUserKey, TStatusKey>(IRepository<TEntity, TKey> repo)
            where TEntity : IOperation<TKey, TUserKey, TStatusKey>
        {
            return repo.Sync.Synchronize(() => repo.Table.Where(e => e.Date.Date == DateTime.Now.Date));
        }
    }
}
