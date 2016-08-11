using System;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class MoneyTransferRepository : IMoneyTransferRepository<MoneyTransfer, int, string, int>
    {
        public IRepository<MoneyTransfer, int> Repository { get; } =
            (IRepository<MoneyTransfer, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<MoneyTransfer, int>));

        public IEnumerable<MoneyTransfer> GetDataByCurrentDay() =>
            OperationHelper.GetDataByCurrentDay<MoneyTransfer, int, string, int>(Repository);

        public IEnumerable<MoneyTransfer> GetDataByPeriod(DateTime? start, DateTime? end) =>
            OperationHelper.GetDataByPeriod<MoneyTransfer, int, string, int>(Repository, start, end);

        public int GetNextDailyNumber() =>
            OperationHelper.GetNextDailyNumber<MoneyTransfer, int, string, int>(Repository);
    }
}