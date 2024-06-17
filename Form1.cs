using AntdUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MYSQL数据迁移工具
{
    public partial class Form1 : AntdUI.Window
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_getDatabases_Click(object sender, EventArgs e)
        {
            Status("加载数据库列表中", AntdUI.TState.Processing);
            string host = input_host.Text;
            if (host == String.Empty)
            {
                Status("数据库主机地址不能为空", AntdUI.TState.Error);
                return;
            }
            string port = input_port.Value.ToString();
            if (port == String.Empty)
            {
                Status("数据库端口不能为空", AntdUI.TState.Error);
                return;
            }
            string username = input_username.Text;
            if (username == String.Empty)
            {
                Status("数据库用户名不能为空", AntdUI.TState.Error);
                return;
            }
            string password = input_password.Text;
            if (password == String.Empty)
            {
                Status("数据库密码不能为空", AntdUI.TState.Error);
                return;
            }
            try
            {
                var dbs = Database.MySQL.GetDatabaseNames(host, port, username, password);
                select_database.Items.Clear();
                select_database.Items.AddRange(dbs.ToArray());
                if (dbs.Count > 0)
                {
                    select_database.SelectedIndex = 0;
                }
                Status("数据库列表加载完成", AntdUI.TState.Success);
            }
            catch (Exception ex)
            {
                Status("加载数据库列表错误：" + ex.Message, AntdUI.TState.Error);
            }

        }




        private void button_test_Click(object sender, EventArgs e)
        {
            Status("测试中", AntdUI.TState.Processing);
            string host = input_host.Text;
            if (host == String.Empty)
            {
                Status("数据库主机地址不能为空", AntdUI.TState.Error);
                return;
            }
            string port = input_port.Value.ToString();
            if (port == String.Empty)
            {
                Status("数据库端口不能为空", AntdUI.TState.Error);
                return;
            }
            string username = input_username.Text;
            if (username == String.Empty)
            {
                Status("数据库用户名不能为空", AntdUI.TState.Error);
                return;
            }
            string password = input_password.Text;
            if (password == String.Empty)
            {
                Status("数据库密码不能为空", AntdUI.TState.Error);
                return;
            }
            string database = select_database.Text;
            if (database == String.Empty)
            {
                Status("请选择有效数据库", AntdUI.TState.Error);
                return;
            }
            try
            {
                var dbs = Database.MySQL.GetTableNames(host, port, username, password, database);
                Status($"连接成功，检索到数据库{database}有数据表{dbs.Count}个", AntdUI.TState.Success);
            }
            catch (Exception ex)
            {
                Status("数据库连接失败：" + ex.Message, AntdUI.TState.Error);
            }

        }



        private void Status(string msg, AntdUI.TState state)
        {
            //更新UI
            if (badge_status.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    badge_status.Visible = true;
                    badge_status.Text = msg;
                    badge_status.State = state;
                }));
            }
            else
            {
                badge_status.Visible = true;
                badge_status.Text = msg;
                badge_status.State = state;
            }
            switch (state)
            {
                case TState.Success:
                    AntdUI.Message.success(this, msg, Font);
                    break;
                case TState.Error:
                    AntdUI.Message.error(this, msg, Font);
                    break;
                case TState.Warn:
                    AntdUI.Message.warn(this, msg, Font);
                    break;
                case TState.Primary:
                    AntdUI.Message.info(this, msg, Font);
                    break;
            }
        }

        private void ProgressChange(float value)
        {
            //更新UI
            if (progress_db.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    progress_db.Value = (float)value;
                    progress_db.Text = $"{value * 100}%";
                }));
            }
            else
            {
                progress_db.Value = (float)value;
                progress_db.Text = $"{value * 100}%";
            }

        }


        #region 备份

        private void button_backup_Click(object sender, EventArgs e)
        {
            string host = input_host.Text;
            if (host == String.Empty)
            {
                Status("数据库主机地址不能为空", AntdUI.TState.Error);
                return;
            }
            string port = input_port.Value.ToString();
            if (port == String.Empty)
            {
                Status("数据库端口不能为空", AntdUI.TState.Error);
                return;
            }
            string username = input_username.Text;
            if (username == String.Empty)
            {
                Status("数据库用户名不能为空", AntdUI.TState.Error);
                return;
            }
            string password = input_password.Text;
            if (password == String.Empty)
            {
                Status("数据库密码不能为空", AntdUI.TState.Error);
                return;
            }
            string database = select_database.Text;
            if (database == String.Empty)
            {
                Status("请选择有效数据库", AntdUI.TState.Error);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "备份文件存储位置";
            dialog.Filter = "SQL脚本文件(*.sql)|*.sql|全部文件(*.*)|*.*";
            dialog.FileName = (select_database.Text != string.Empty ? select_database.Text + "_" : "") + "backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql";
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Status("数据库备份中", AntdUI.TState.Processing);
                string filename = dialog.FileName;
                Database.MySQL.Model model = new Database.MySQL.Model();
                model.Host = host;
                model.Port = port;
                model.Username = username;
                model.Password = password;
                model.Database = database;
                model.FileName = filename;
                BackgroundWorker backupWorker = new BackgroundWorker();
                backupWorker.DoWork += BackupWorker_DoWork;
                backupWorker.RunWorkerCompleted += BackupWorker_RunWorkerCompleted;
                backupWorker.RunWorkerAsync(model);
            }
        }

        private void BackupWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            //Status("备份结束", AntdUI.TState.Success);
        }

        private void BackupWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Database.MySQL.Model model = (Database.MySQL.Model)e.Argument;
            Database.MySQL.Log += (message, code) =>
            {
                switch (code)
                {
                    case 0:
                        Status(message, AntdUI.TState.Success);
                        break;
                    case 1:
                        Status(message, AntdUI.TState.Processing);
                        break;
                    case -1:
                        Status(message, AntdUI.TState.Error);
                        break;
                }
            };
            Database.MySQL.ProgressChanged += progress =>
            {
                ProgressChange((float)progress);
            };
            Database.MySQL.Backup(model.Host, model.Port, model.Username, model.Password, model.Database, model.FileName);
        }

        #endregion


        #region 恢复

        private void button_recover_Click(object sender, EventArgs e)
        {
            string host = input_host.Text;
            if (host == String.Empty)
            {
                Status("数据库主机地址不能为空", AntdUI.TState.Error);
                return;
            }
            string port = input_port.Value.ToString();
            if (port == String.Empty)
            {
                Status("数据库端口不能为空", AntdUI.TState.Error);
                return;
            }
            string username = input_username.Text;
            if (username == String.Empty)
            {
                Status("数据库用户名不能为空", AntdUI.TState.Error);
                return;
            }
            string password = input_password.Text;
            if (password == String.Empty)
            {
                Status("数据库密码不能为空", AntdUI.TState.Error);
                return;
            }
            string database = select_database.Text;
            if (database == String.Empty)
            {
                Status("请选择有效数据库", AntdUI.TState.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "备份文件存储位置";
            dialog.Filter = "SQL脚本文件(*.sql)|*.sql|全部文件(*.*)|*.*";
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Status("数据库恢复中", AntdUI.TState.Processing);
                string filename = dialog.FileName;
                Database.MySQL.Model model = new Database.MySQL.Model();
                model.Host = host;
                model.Port = port;
                model.Username = username;
                model.Password = password;
                model.Database = database;
                model.FileName = filename;
                BackgroundWorker recoverWorker = new BackgroundWorker();
                recoverWorker.DoWork += RecoverWorkerWorker_DoWork;
                recoverWorker.RunWorkerCompleted += RecoverWorker_RunWorkerCompleted;
                recoverWorker.RunWorkerAsync(model);
            }
        }

        private void RecoverWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            //Status("恢复结束", AntdUI.TState.Success);
        }

        private void RecoverWorkerWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Database.MySQL.Model model = (Database.MySQL.Model)e.Argument;
            Database.MySQL.Log += (message, code) =>
            {
                switch (code)
                {
                    case 0:
                        Status(message, AntdUI.TState.Success);
                        break;
                    case 1:
                        Status(message, AntdUI.TState.Processing);
                        break;
                    case -1:
                        Status(message, AntdUI.TState.Error);
                        break;
                }
            };
            Database.MySQL.ProgressChanged += progress =>
            {
                ProgressChange((float)progress);
            };
            Database.MySQL.Recover(model.Host, model.Port, model.Username, model.Password, model.Database, model.FileName);
        }
        #endregion

        private void button_github_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/ZeroDeng01/mysql-backup";
            try
            {
                // 使用默认浏览器打开指定网址
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
