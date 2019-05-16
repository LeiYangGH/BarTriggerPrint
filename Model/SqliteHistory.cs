using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public static class SqliteHistory
    {
        private static string connStr = $"Data Source={Constants.SqliteFileName};Version=3;";
        public static void CreateDb()
        {
            if (!System.IO.File.Exists(Constants.SqliteFileName))
            {
                Log.Instance.Logger.Info($"开始创建条码打印纪录数据库文件:{Constants.SqliteFileName}.");
                try
                {
                    SQLiteConnection.CreateFile(Constants.SqliteFileName);

                    using (var conn = new SQLiteConnection(connStr))
                    {
                        conn.Open();
                        string sql = "create table barcodehistory (componenttype TEXT, barcode TEXT, printdate TEXT)";
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.Logger.Error($"创建条码打印纪录数据库文件出错:{ex.Message}");
                }

            }
        }

        public static void InsertPrintHistroy(string componenttype, string barcode)
        {
            try
            {
                string sql = "insert into barcodehistory (componenttype, barcode, printdate) values (@componenttype, @barcode, @printdate)";
                using (var conn = new SQLiteConnection(connStr))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@componenttype", componenttype);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@printdate", DateTime.Now.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error($"添加条码打印纪录出错:{ex.Message}");
            }
        }

        public static DataTable QueryRecent(string componenttype, int count)
        {
            DataTable dt = new DataTable();
            string cmd = $"select barcode, printdate from barcodehistory where componenttype = '{componenttype}' order by rowid DESC LIMIT {count}";
            try
            {
                dt = new DataTable();
                using (var da = new SQLiteDataAdapter(cmd, connStr))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error($"sql={cmd}出错:{ex.Message}");
            }
            return dt;
        }


    }
}
