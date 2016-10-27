using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conan.DAL
{
    public class SqlServerProvider
    {
        public static string GetSqlForSelectBuilder(SelectBuilderData data)
        {
            var sql = new StringBuilder();
            if (data.PagingCurrentPage == 1)
            {
                if (data.PagingItemsPerPage == 0)
                    sql.Append("select");
                else
                    // support distinct start
                    //sql.Append("select top " + data.PagingItemsPerPage.ToString());
                    if (data.Select.ToLower().Trim().StartsWith("distinct"))
                {
                    sql.Append("select distinct top " + data.PagingItemsPerPage.ToString());
                    data.Select = data.Select.Trim().Substring(8);
                }
                else
                {
                    sql.Append("select top " + data.PagingItemsPerPage.ToString());
                }
                //modify end


                sql.Append(" " + data.Select);
                sql.Append(" from " + data.From);
                if (data.WhereSql.Length > 0)
                    sql.Append(" where " + data.WhereSql);
                if (data.GroupBy.Length > 0)
                    sql.Append(" group by " + data.GroupBy);
                if (data.Having.Length > 0)
                    sql.Append(" having " + data.Having);
                if (data.OrderBy.Length > 0)
                    sql.Append(" order by " + data.OrderBy);
                return sql.ToString();
            }
            else
            {
                sql.Append(" from " + data.From);
                if (data.WhereSql.Length > 0)
                    sql.Append(" where " + data.WhereSql);
                if (data.GroupBy.Length > 0)
                    sql.Append(" group by " + data.GroupBy);
                if (data.Having.Length > 0)
                    sql.Append(" having " + data.Having);

                var pagedSql = string.Format(@"with PagedPersons as
								(
									select top 100 percent {0}, row_number() over (order by {1}) as FLUENTDATA_ROWNUMBER
									{2}
								)
								select *
								from PagedPersons
								where fluentdata_RowNumber between {3} and {4}",
                                             data.Select,
                                             data.OrderBy,
                                             sql,
                                            ((data.PagingCurrentPage * data.PagingItemsPerPage) - data.PagingItemsPerPage + 1),
                                             (data.PagingCurrentPage * data.PagingItemsPerPage));
                return pagedSql;
            }
        }

        public static string GetSqlForTotalBuilder(SelectBuilderData data)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(0) as result");
            sql.AppendFormat(" from {0}", data.From);
            if (data.WhereSql.Length > 0)
            {
                sql.Append(" where ");
                sql.Append(data.WhereSql);
            }
            return sql.ToString();
        }
    }


    public class SelectBuilderData
    {
        public int PagingCurrentPage { get; set; } = 1;
        public int PagingItemsPerPage { get; set; } = 0;
        public string Having { get; set; } = "";
        public string GroupBy { get; set; } = "";
        public string OrderBy { get; set; } = "";
        public string From { get; set; } = "";
        public string Select { get; set; } = "";
        public string WhereSql { get; set; } = "";
    }
}
