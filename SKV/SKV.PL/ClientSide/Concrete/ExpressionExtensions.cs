using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace SKV.PL.ClientSide.Concrete
{
    public static class ExpressionExtensions
    {
        public static TCustomAttribute GetAttribute<TCustomAttribute, T, V>(this Expression<Func<T, V>> expression) where TCustomAttribute : Attribute
        {
            var member = (expression.Body as MemberExpression).Member;
            if (member == null)
                throw new InvalidOperationException();

            var attr = member.GetCustomAttributes(typeof(TCustomAttribute), false).FirstOrDefault() as TCustomAttribute;
            if(attr == null) //overrided property attribute
                return Attribute.GetCustomAttributes(expression.Parameters[0].Type.GetProperty(member.Name)).FirstOrDefault() as TCustomAttribute;

            return attr; //normal property attribute
        }

        public static string GetPathWithoutSource<T, V>(this Expression<Func<T, V>> expression)
        {
            var path = expression.Body.ToString();
            return path.Substring(path.IndexOf('.') + 1);
        }
    }
}