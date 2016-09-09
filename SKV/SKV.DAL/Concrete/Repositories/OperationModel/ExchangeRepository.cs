using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class ExchangeRepository : IExchangeRepository<Exchange, int, ExchangeSource, string, int, int, int>
    {
        public IRepository<Exchange, int> Repository { get; } =
            (IRepository<Exchange, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Exchange, int>));

        public IEnumerable<Exchange> GetDataByCurrentDay() =>
            OperationHelper.GetDataByCurrentDay<Exchange, int, string, int>(Repository);

        public IEnumerable<Exchange> GetDataByPeriod(DateTime? start, DateTime? end) =>
            OperationHelper.GetDataByPeriod<Exchange, int, string, int>(Repository, start, end);

        public IEnumerable<Exchange> GetExchangesByClientId(int client_id) =>
            Repository.Sync.Synchronize(() => Repository.Table.Where(e => e.ClientId == client_id));

        public IEnumerable<Exchange> GetExchangesCanceledByClientReason(int client_id) =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.StatusInstance)
                                                        .Where(e => e.StatusInstance.StatusCode == (int)ExchangeStatus.CanceledByClientReason || 
                                                                    e.StatusInstance.StatusCode == (int)ExchangeStatus.CanceledWithAddingToBlackList || 
                                                                    e.StatusInstance.StatusCode == (int)ExchangeStatus.CanceledByDayExpired));

        public IEnumerable<Exchange> GetExpiredExchanges() =>
            Repository.Sync.Synchronize(() => Repository.Table
                                                        .Include(e => e.StatusInstance)
                                                        .Where(e => e.StatusInstance.StatusCode == (int)ExchangeStatus.Claim ||
                                                                    e.StatusInstance.StatusCode == (int)ExchangeStatus.Order));

        public int GetNextDailyNumber() =>
            OperationHelper.GetNextDailyNumber<Exchange, int, string, int>(Repository);
    }
}
