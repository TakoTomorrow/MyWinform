using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyWinform
{
    internal class ExcelWork
    {
        static public DataTable WorksheetMapToDataTable(ExcelWorksheet worksheet)
        {
            //获取worksheet的行数
            int rows = worksheet.Dimension.End.Row;
            //获取worksheet的列数
            int cols = worksheet.Dimension.End.Column;

            DataTable dt = new DataTable(worksheet.Name);
            DataRow dr = null;
            for (int i = 1; i <= rows; i++)
            {
                if (i > 1)
                    dr = dt.Rows.Add();

                for (int j = 1; j <= cols; j++)
                {
                    //默认将第一行设置为datatable的标题
                    if (i == 1)
                        dt.Columns.Add(worksheet.Cells[i, j]?.Value.ToString());
                    //剩下的写入datatable
                    else
                        dr[j - 1] = worksheet.Cells[i, j]?.Value.ToString();
                }
            }
            return dt;
        }

    }
}
