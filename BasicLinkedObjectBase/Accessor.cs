using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicLinkedObjectBase
{
    internal static class Accessor<T, TAttribute> where TAttribute : Attribute
    {
        static private readonly ParameterExpression instance = Expression.Parameter(typeof(T));
        static public readonly Func<T, string> ReadIDValue = Expression.Lambda<Func<T, string>>(Expression.Property(instance, typeof(T).GetProperties().Single(p => p.GetCustomAttribute<TAttribute>() != null)), instance).Compile();
    }
}
