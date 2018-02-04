using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Lists.Product;

namespace BL.Objects.Lists.Extensions
{
    public static class ListExtension
    {
        public static DataTable ToTvpLongList(this IEnumerable<long> source, string columnName = "ID")
        {
            if (source == null)
                return null;

            var table = new DataTable();
            table.Columns.Add(columnName);

            foreach (var tag in source)
            {
                var row = table.NewRow();

                row["ID"] = tag;

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable ToTvp(this List<ProductList> source)
        {
            if (source == null)
                return null;

            var table = new DataTable();

            table.Columns.Add("Id", typeof(long));
            table.Columns.Add("Title", typeof(string));


            foreach (var item in source)
            {
                var row = table.NewRow();

                row["Id"] = item.Id == null ? DBNull.Value : (object)item.Id.Value;
                row["Title"] = item.Title;

                table.Rows.Add(row);
            }

            return table;
        }

    }
}
