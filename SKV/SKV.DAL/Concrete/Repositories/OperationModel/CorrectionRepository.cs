using System;
using System.Collections.Generic;

using Ninject;

using SKV.DAL.Tools;
using SKV.DAL.Abstract.Database;
using SKV.ML.Concrete.Model.OperationModel;
using SKV.DAL.Abstract.Repositories.OperationModel;

namespace SKV.DAL.Concrete.Repositories.OperationModel
{
    public class CorrectionRepository : ICorrectionRepository<Correction, int, string, int>
    {
        public IRepository<Correction, int> Repository { get; } =
            (IRepository<Correction, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<Correction, int>));

        public IEnumerable<Correction> GetDataByCurrentDay() => 
            OperationHelper.GetDataByCurrentDay<Correction, int, string, int>(Repository);

        public IEnumerable<Correction> GetDataByPeriod(DateTime? start, DateTime? end) =>
            OperationHelper.GetDataByPeriod<Correction, int, string, int>(Repository, start, end);

        public int GetNextDailyNumber() =>
            OperationHelper.GetNextDailyNumber<Correction, int, string, int>(Repository);
    }
}
