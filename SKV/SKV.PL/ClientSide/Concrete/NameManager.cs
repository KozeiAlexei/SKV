using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.PL.ClientSide.Concrete
{
    public class NameManager
    {
        public static string GetName(string name) => Resources.Resource.ResourceManager.GetString(name);
    }
}