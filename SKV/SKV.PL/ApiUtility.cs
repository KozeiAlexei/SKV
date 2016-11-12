using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKV.PL
{
    public class PLUtility
    {
        public static void ThrowIfNull<TObject>(TObject obj, string name, Action postback) where TObject : class
        {
            if (obj == null)
                throw new ArgumentNullException(name);
            postback();
        }
    }
}