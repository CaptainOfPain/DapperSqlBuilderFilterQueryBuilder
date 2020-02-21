using QueryFilter.Enums;
using QueryFilter.Extensions;

namespace QueryFilter.Models
{
    public class FilterValue
    {
        public decimal Value { get; }
        public FilterAction Action { get; }

        public FilterValue(decimal value, FilterAction action)
        {
            Value = value;
            Action = action;
        }

        public override string ToString()
        {
            return $"{Action.GetStringValue()} {Value}";
        }

        public string ToSql()
        {
            return $"{Action.GetSqlValue()} {Value}";
        }
    }
}