using System;

using SKV.ML.Abstract.Entity;

namespace SKV.ML.Abstract.Model.OperationModel
{
    public interface IOperation<TKey, TUserKey, TStatusKey>: IEntity<TKey>
    {
        int DailyNumber { get; set; }

        DateTime Date { get; set; }

        TUserKey UserId { get; set; }

        TStatusKey StatusId { get; set; }
    }
}
