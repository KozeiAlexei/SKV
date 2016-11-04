using Ninject;

using SKV.PL.ClientSide.Abstract;

namespace SKV.PL.ClientSide.Concrete
{
    public class LocalizedData
    {
        private ILocalizedDataProvider<string, string> provider = PLDependencyResolver.Kernel.Get<ILocalizedDataProvider<string, string>>();

        public LocalizedData(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }

        public string Value
        {
            get
            {
                return provider.GetLocalizedData(Key);
            }
        }
    }
}