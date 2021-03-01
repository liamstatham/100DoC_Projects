using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Analysis;
using System.Data.SQLite;

namespace Log_File_Search
{
    class SQLiteDB
    {
        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }
        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string CreateTable = @"CREATE TABLE if not exists Logs 
                (LogID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE
                ,Created DATETIME
                ,Method TEXT
                ,UriStem TEXT
                ,UriQuery TEXT
                ,Port INTEGER
                ,IP TEXT
                ,UserAgent TEXT
                ,URL TEXT";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = CreateTable;
            sqlite_cmd.ExecuteNonQuery();

        }

        // to add to table, will need to parameterise the variables, find a way to get the linesp data to this method. 
        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"INSERT INTO SampleTable
               (Col1, Col2) VALUES('Test Text ', 1); ";
         sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = @"INSERT INTO SampleTable
               (Col1, Col2) VALUES('Test1 Text1 ', 2); ";
         sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = @"INSERT INTO SampleTable
               (Col1, Col2) VALUES('Test2 Text2 ', 3); ";
         sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = @"INSERT INTO SampleTable1
               (Col1, Col2) VALUES('Test3 Text3 ', 3); ";
         sqlite_cmd.ExecuteNonQuery();

        }
    }
}
