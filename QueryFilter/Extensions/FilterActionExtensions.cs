using System;
using System.Linq;
using System.Reflection;
using QueryFilter.Attributes;

namespace QueryFilter.Extensions
{
    public static class FilterActionExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes<StringValueAttribute>();
            return attributes.First().Action;
        }
        public static string GetSqlValue(this Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes<SqlValueAttribute>();
            return attributes.First().Action;
        }
    }
}