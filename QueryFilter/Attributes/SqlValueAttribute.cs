using System;

namespace QueryFilter.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SqlValueAttribute : Attribute
    {
        public string Action { get; }
        public SqlValueAttribute(string action)
        {
            Action = action;
        }
    }
}