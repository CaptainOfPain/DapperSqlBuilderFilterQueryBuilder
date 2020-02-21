using System;
using System.Text.RegularExpressions;
using QueryFilter.Enums;
using QueryFilter.Models;

namespace QueryFilter.Extensions
{
    public static class FilterValueExtensions
    {
        public static FilterValue ToFilterValue(this string filter)
        {
            var value = Convert.ToDecimal(Regex.Match(filter, @"\d+").Value);
            if (filter.Contains(FilterAction.GreaterOrEqual.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.GreaterOrEqual);
            }
            else if (filter.Contains(FilterAction.Greater.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.Greater);
            }
            else if (filter.Contains(FilterAction.LowerOrEqual.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.LowerOrEqual);
            }
            else if (filter.Contains(FilterAction.Lower.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.Lower);
            }
            else if (filter.Contains(FilterAction.NotEqual.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.NotEqual);
            }
            else if (filter.Contains(FilterAction.Equal.GetStringValue()))
            {
                return new FilterValue(value, FilterAction.Equal);
            }
            throw new Exception("Not supported action");
        }
    }
}