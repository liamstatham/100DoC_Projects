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
        
        public static DataTable CreateTable()
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
                                  new DataColumn("UserAgent",typeof(String)),
                                  new DataColumn("URL",typeof(String))
                                };
            logTable.Columns.AddRange(cols);
            logTable.PrimaryKey = new DataColumn[] { logTable.Columns["LogId"] };
            return logTable;

        }
        public static void InsertLogs(DataTable logTable ,string linesp)
        {
            
            // split linesp
            var bigdate = linesp[0] + ' ' + linesp[1];
            var method = linesp[3];
            var uriStem = linesp[4];
            var uriQuery = linesp[5];
            var ip = linesp[8];
            var userAgent = linesp[9];
            var url = linesp[10];

            DataRow row = logTable.NewRow();
            row["CreatedDate"] = bigdate;
            row["Method"] = method;
            row["UriStem"] = uriStem;
            row["UriQuery"] = uriQuery;
            row["IP"] = ip;
            row["UserAgent"] = userAgent;
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
        public DataTable LogTable;
    }

}
