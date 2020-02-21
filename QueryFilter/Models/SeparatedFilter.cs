using QueryFilter.Enums;

namespace QueryFilter.Models
{
    public class SeparatedFilter
    {
        public FilterValue Filter { get; }
        public FilterAction Action { get; }

        public SeparatedFilter(FilterValue filter, FilterAction action)
        {
            Filter = filter;
            Action = action;
        }
    }
}
