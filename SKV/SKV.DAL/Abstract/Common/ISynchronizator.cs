using System;

namespace SKV.DAL.Abstract.Common
{
    public interface ISynchronizator
    {
        TResult Synchronize<TResult>(Func<TResult> func);
    }
}
