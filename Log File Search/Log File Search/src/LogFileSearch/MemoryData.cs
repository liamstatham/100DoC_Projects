using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Log_File_Search
{
    public class MemoryData
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=net-5.0
        // data table info
        
        public DataTable CreateTable()
        {
            //define table
            DataTable logTable = new DataTable("Log_Table");

            // create autoincrement column & add to table
            DataColumn LogId = new DataColumn();
            LogId.DataType = System.Type.GetType("System.Int32");
            LogId.AutoIncrement = true;
            LogId.AutoIncrementSeed = 1;
            LogId.AutoIncrementStep = 1;
            logTable.Columns.Add(LogId);

            //define Other columns
            DataColumn[] cols =
                                {
                                  new DataColumn("CreatedDate",typeof(DateTime)),
                                  new DataColumn("Method",typeof(String)),
                                  new DataColumn("UriStem",typeof(String)),
                                  new DataColumn("UriQuery",typeof(String)),
                                  new DataColumn("IP",typeof(String)),
                                  new DataColumn("User",typeof(String)),
                                  new DataColumn("URL",typeof(String))
                                };
            logTable.Columns.AddRange(cols);
            logTable.PrimaryKey = new DataColumn[] { logTable.Columns["LogId"] };
            return logTable;

        }
        public static void InsertLogs(DataTable logTable ,string[] linesp)
        {
            
            // split linesp
            var bigdate = linesp[0] + ' ' + linesp[1];
            var method = linesp[3];
            var uriStem = linesp[4];
            var uriQuery = linesp[5];
            var ip = linesp[8];
            var user = linesp[7];
            var url = linesp[10];

            // this breaks, throws null reference exception logTable was null
            DataRow row = logTable.NewRow();
            row["CreatedDate"] = bigdate;
            row["Method"] = method;
            row["UriStem"] = uriStem;
            row["UriQuery"] = uriQuery;
            row["IP"] = ip;
            row["User"] = user;
            row["URL"] = url;

            try
            {
                logTable.Rows.Add(row);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ShowTable(DataTable logTable)
        {
            foreach (DataColumn col in logTable.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in logTable.Rows)
            {
                foreach (DataColumn col in logTable.Columns)
                {
                    if (col.DataType.Equals(typeof(DateTime)))
                        Console.Write("{0,-14:d}", row[col]);
                    else if (col.DataType.Equals(typeof(Decimal)))
                        Console.Write("{0,-14:C}", row[col]);
                    else
                        Console.Write("{0,-14}", row[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public DataTable LogTable;
    }

}
