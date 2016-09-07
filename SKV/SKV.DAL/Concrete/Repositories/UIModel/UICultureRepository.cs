using Ninject;

using SKV.DAL.Abstract.Database;
using SKV.DAL.Concrete.Model.UIModel;
using SKV.DAL.Abstract.Repositories.UIModel;

namespace SKV.DAL.Concrete.Repositories.UIModel
{
    public class UICultureRepository : IUICultureRepository<UICulture, int>
    {
        public IRepository<UICulture, int> Repository { get; } =
            (IRepository<UICulture, int>)DALDependencyResolver.Kernel.Get(typeof(IRepository<UICulture, int>));
    }
}
