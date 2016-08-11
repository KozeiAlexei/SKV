using System;

namespace SKV.DAL.Tools
{
    public static class DynamicCast
    {
        public static T To<T>(object obj) => (T)Convert.ChangeType(obj, typeof(T));
    }
}
