using System;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class InventarisationRepository : IInventarisationRepository<Inventarisation, int, string, int>
    {
        public IRepository<Inventarisation, int> Repository { get; } =
            (IRepository<Inventarisation, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Inventarisation, int>));

        public IEnumerable<Inventarisation> GetDataByCurrentDay() =>
            OperationHelper.GetDataByCurrentDay<Inventarisation, int, string, int>(Repository);

        public IEnumerable<Inventarisation> GetDataByPeriod(DateTime? start, DateTime? end) =>
            OperationHelper.GetDataByPeriod<Inventarisation, int, string, int>(Repository, start, end);

        public int GetNextDailyNumber() =>
            OperationHelper.GetNextDailyNumber<Inventarisation, int, string, int>(Repository);
    }
}