using SKV.PL.ClientSide.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.PL.ClientSide.Concrete
{
    public class LocalizedDataProvider : ILocalizedDataProvider<string, string>
    {
        public string GetLocalizedData(string key) => Resources.Resource.ResourceManager.GetString(key);
    }
}