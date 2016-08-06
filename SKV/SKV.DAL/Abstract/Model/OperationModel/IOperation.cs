using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.OperationModel
{
    public interface IOperation<TKey, TUserKey, TStatusKey>: IEntity<TKey>, ICloneableFrom<IOperation<TKey, TUserKey, TStatusKey>>
    {
        int Number { get; set; }

        DateTime Date { get; set; }

        TUserKey UserId { get; set; }

        TStatusKey StatusId { get; set; }
    }
}
