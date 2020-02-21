using QueryFilter.Attributes;

namespace QueryFilter.Enums
{
    public enum FilterAction
    {
        [StringValue(">")]
        [SqlValue(">")]
        Greater = 1,
        [StringValue(">=")]
        [SqlValue(">=")]
        GreaterOrEqual = 2,
        [StringValue("<")]
        [SqlValue("<")]
        Lower = 3,
        [StringValue("<=")]
        [SqlValue("<=")]
        LowerOrEqual = 4,
        [StringValue("==")]
        [SqlValue("=")]
        Equal = 5,
        [StringValue("&&")]
        [SqlValue("AND")]
        And = 6,
        [StringValue("||")]
        [SqlValue("OR")]
        Or = 7,
        [StringValue("!=")]
        [SqlValue("<>")]
        NotEqual = 8
    }
}