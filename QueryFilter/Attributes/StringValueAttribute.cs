using System;

namespace QueryFilter.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        public string Action { get; }
        public StringValueAttribute(string action)
        {
            Action = action;
        }
    }
}