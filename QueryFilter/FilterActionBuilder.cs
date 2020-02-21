using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using QueryFilter.Enums;
using QueryFilter.Extensions;
using QueryFilter.Models;

namespace QueryFilter
{
    public class FilterActionBuilder
    {
        public void BuildFilter(SqlBuilder sqlBuilder, string filter, string columnName)
        {
            var filters = SeparateFilters(filter);
            ApplyWhereStatement(filters, columnName, sqlBuilder);
        }

        private void ApplyWhereStatement(IEnumerable<SeparatedFilter> filters, string columnName, SqlBuilder sqlBuilder)
        {
            foreach (var separatedFilter in filters)
            {
                if (separatedFilter.Action == FilterAction.Or)
                {
                    sqlBuilder.OrWhere($"{columnName} {separatedFilter.Filter.ToSql()}");
                }
                else if (separatedFilter.Action == FilterAction.And)
                {

                    sqlBuilder.Where($"{columnName} {separatedFilter.Filter.ToSql()}");
                }
            }
        }

        private IEnumerable<SeparatedFilter> SeparateFilters(string filter)
        {
            var separatedFilters = new List<SeparatedFilter>();
            var separatedAndFilters = filter.Split(FilterAction.And.GetStringValue().ToCharArray()).ToList();
            separatedAndFilters.RemoveAll(string.IsNullOrWhiteSpace);
            foreach (var separatedAndFilter in separatedAndFilters)
            {
                if (separatedAndFilter.Contains(FilterAction.Or.GetStringValue()))
                {
                    var filters = separatedAndFilter.Split(FilterAction.Or.GetStringValue().ToCharArray()).ToList();
                    separatedFilters.Add(new SeparatedFilter(filters.First().ToFilterValue(), FilterAction.Or));
                    filters.Remove(filters.First());
                    filters.RemoveAll(string.IsNullOrWhiteSpace);
                    separatedFilters.AddRange(filters.Select(x => new SeparatedFilter(x.ToFilterValue(), FilterAction.Or)));
                }
                else
                {
                    separatedFilters.Add(new SeparatedFilter(separatedAndFilter.ToFilterValue(), FilterAction.And));
                }
            }

            return separatedFilters;
        }
    }
}