using SKV.DAL.Abstract.Database;
using SKV.DAL.Abstract.Model.CommonModel;

namespace SKV.DAL.Abstract.Repositories.CommonModel
{
    public interface ISystemSettingsRepository<TEntity, TKey> : IRepositoryComposition<TEntity, TKey>
        where TEntity : ISystemSettings<TKey>
    {
        TEntity GetSystemSettings();
    }
}
