using MySql.Data.MySqlClient;

namespace MYSQL数据迁移工具.Database
{
    public class MySQL
    {
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static List<string> GetDatabaseNames(string host, string port, string username, string password)
        {

            var databaseNames = new List<string>();
            string connectionString = $"Server={host};Port={port};User ID={username};Password={password};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("🚀 Connected to the database successfully.");

                string query = "SHOW DATABASES;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        databaseNames.Add(reader[0].ToString());
                    }
                }
            }

            return databaseNames;
        }




        /// <summary>
        /// 获取数据库表名字
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static List<string> GetTableNames(string host, string port, string username, string password, string database)
        {
            var tableNames = new List<string>();
            string connectionString = $"Server={host};Port={port};User ID={username};Password={password};Database={database};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine($"🚀 Connected to the database '{database}' successfully.");

                string query = "SHOW TABLES;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableNames.Add(reader[0].ToString());
                    }
                }
            }

            return tableNames;
        }

        public static event Action<string,int> Log;
        public static event Action<decimal> ProgressChanged;
        /// <summary>
        /// 数据备份
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <param name="filename"></param>
        public static void Backup(string host, string port, string username, string password, string database, string filename)
        {
            try
            {
                string connectionString = $"server={host};port={port};user={username};password={password};database={database};";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ExportProgressChanged += (sender, e) =>
                            {

                                Log?.Invoke($"备份中：{e.CurrentTableName}",1);
                                if (e.TotalRowsInCurrentTable > 0)
                                {
                                    ProgressChanged?.Invoke(Math.Round((decimal)e.CurrentRowIndexInAllTables / (decimal)e.TotalRowsInAllTables, 2));
                                }
                                else {
                                    ProgressChanged?.Invoke(0);
                                }
                            };

                            mb.ExportCompleted += (sender, args) =>
                            {
                                Log?.Invoke("备份成功",0);
                            };
                            cmd.Connection = conn;

                            mb.ExportInfo.GetTotalRowsMode = GetTotalRowsMethod.SelectCount;

                            conn.Open();
                            mb.ExportToFile(filename);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"备份过程中出现错误: {ex.Message}", -1);
            }
        }

        /// <summary>
        /// 数据恢复
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <param name="filename"></param>
        public static void Recover(string host, string port, string username, string password, string database, string filename)
        {
            try
            {
                string connectionString = $"server={host};port={port};user={username};password={password};database={database};";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ImportProgressChanged += (sender, e) =>
                            {

                                Log?.Invoke($"恢复中：当前处理{e.CurrentBytes}字节",1);
                                if (e.TotalBytes > 0)
                                {
                                    ProgressChanged?.Invoke(Math.Round((decimal)e.CurrentBytes / (decimal)e.TotalBytes, 2));
                                }
                                else
                                {
                                    ProgressChanged?.Invoke(0);
                                }
                            };

                            mb.ImportCompleted += (sender, args) =>
                            {
                                Log?.Invoke("恢复成功",0);
                            };
                            cmd.Connection = conn;

                            conn.Open();
                            mb.ImportFromFile(filename);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke($"恢复过程中出现错误: {ex.Message}",-1);
            }
        }










        public class Model {
            public string Host { get; set; }

            public string Port { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string? Database { get; set; }

            public string? FileName { get; set; }

        }







    }
}
