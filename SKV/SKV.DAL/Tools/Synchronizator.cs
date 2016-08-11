using System;
using System.Threading;

using NLog;

using SKV.DAL.Abstract.Common;

namespace SKV.DAL.Tools
{
    public class Synchronizator : ISynchronizator
    {
        private object sync_context = default(object);

        private ILogger logger = LogManager.GetCurrentClassLogger();

        public Synchronizator(object sync_context)
        {
            this.sync_context = sync_context;
        }

        public TResult Synchronize<TResult>(Func<TResult> func)
        {
            var result = default(TResult);
            try
            {
                Monitor.Enter(sync_context);
                result = func();
            }
            catch(Exception ex)
            {
                logger.Debug(ex);
                result = default(TResult);
            }
            finally
            {
                Monitor.Exit(sync_context);
            }

            return result;
        }
    }
}
