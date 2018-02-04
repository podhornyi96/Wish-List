using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Product.Extensions
{
    public static class ProductExtension
    {
        public static DataTable ToTvp(this List<ProductItem> source)
        {
            if (source == null)
                return null;

            var table = new DataTable();
            
            table.Columns.Add("ProductId", typeof(long));
            table.Columns.Add("VariantId", typeof(long));

            foreach (var item in source)
            {
                var row = table.NewRow();
                
                row["ProductId"] = item.ProductId;
                row["VariantId"] = item.VariantId;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
