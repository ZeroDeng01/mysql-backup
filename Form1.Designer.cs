namespace MYSQL数据迁移工具
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            windowBar1 = new AntdUI.WindowBar();
            input_host = new AntdUI.Input();
            button_backup = new AntdUI.Button();
            button_recover = new AntdUI.Button();
            label1 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            input_port = new AntdUI.InputNumber();
            label4 = new AntdUI.Label();
            input_username = new AntdUI.Input();
            label5 = new AntdUI.Label();
            input_password = new AntdUI.Input();
            button_test = new AntdUI.Button();
            label2 = new AntdUI.Label();
            select_database = new AntdUI.Select();
            badge_status = new AntdUI.Badge();
            button_getDatabases = new AntdUI.Button();
            progress_db = new AntdUI.Progress();
            button_github = new AntdUI.Button();
            SuspendLayout();
            // 
            // windowBar1
            // 
            windowBar1.Dock = DockStyle.Top;
            windowBar1.Font = new Font("Microsoft YaHei UI", 12F);
            windowBar1.Location = new Point(0, 0);
            windowBar1.MaximizeBox = false;
            windowBar1.Mode = AntdUI.TAMode.Light;
            windowBar1.Name = "windowBar1";
            windowBar1.Size = new Size(659, 55);
            windowBar1.SubText = "By：ZeroDeng";
            windowBar1.TabIndex = 0;
            windowBar1.Text = "MYSQL数据迁移";
            // 
            // input_host
            // 
            input_host.Font = new Font("Microsoft YaHei UI", 10F);
            input_host.Location = new Point(30, 94);
            input_host.Name = "input_host";
            input_host.PlaceholderText = "数据库主机地址";
            input_host.PrefixSvg = resources.GetString("input_host.PrefixSvg");
            input_host.Size = new Size(600, 40);
            input_host.SuffixText = "";
            input_host.TabIndex = 2;
            input_host.Text = "localhost";
            // 
            // button_backup
            // 
            button_backup.Font = new Font("Microsoft YaHei UI", 10F);
            button_backup.ImageSvg = resources.GetString("button_backup.ImageSvg");
            button_backup.Location = new Point(498, 538);
            button_backup.Name = "button_backup";
            button_backup.Size = new Size(130, 45);
            button_backup.TabIndex = 4;
            button_backup.Text = "备份数据";
            button_backup.Type = AntdUI.TTypeMini.Primary;
            button_backup.Click += button_backup_Click;
            // 
            // button_recover
            // 
            button_recover.Font = new Font("Microsoft YaHei UI", 10F);
            button_recover.ImageSvg = resources.GetString("button_recover.ImageSvg");
            button_recover.Location = new Point(498, 614);
            button_recover.Name = "button_recover";
            button_recover.Size = new Size(130, 45);
            button_recover.TabIndex = 9;
            button_recover.Text = "恢复数据";
            button_recover.Type = AntdUI.TTypeMini.Primary;
            button_recover.Click += button_recover_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 10F);
            label1.Location = new Point(35, 61);
            label1.Name = "label1";
            label1.Size = new Size(95, 27);
            label1.TabIndex = 10;
            label1.Text = "主机";
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft YaHei UI", 10F);
            label3.Location = new Point(35, 138);
            label3.Name = "label3";
            label3.Size = new Size(95, 27);
            label3.TabIndex = 12;
            label3.Text = "端口";
            // 
            // input_port
            // 
            input_port.Location = new Point(30, 171);
            input_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            input_port.MaxLength = 5;
            input_port.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            input_port.Name = "input_port";
            input_port.PlaceholderText = "数据库端口";
            input_port.PrefixSvg = resources.GetString("input_port.PrefixSvg");
            input_port.Size = new Size(600, 40);
            input_port.SuffixSvg = "";
            input_port.TabIndex = 13;
            input_port.Text = "3306";
            input_port.Value = new decimal(new int[] { 3306, 0, 0, 0 });
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft YaHei UI", 10F);
            label4.Location = new Point(35, 218);
            label4.Name = "label4";
            label4.Size = new Size(95, 27);
            label4.TabIndex = 15;
            label4.Text = "用户";
            // 
            // input_username
            // 
            input_username.Font = new Font("Microsoft YaHei UI", 10F);
            input_username.Location = new Point(30, 251);
            input_username.Name = "input_username";
            input_username.PlaceholderText = "数据库用户名";
            input_username.PrefixSvg = resources.GetString("input_username.PrefixSvg");
            input_username.Size = new Size(600, 40);
            input_username.SuffixText = "";
            input_username.TabIndex = 14;
            input_username.Text = "root";
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft YaHei UI", 10F);
            label5.Location = new Point(36, 298);
            label5.Name = "label5";
            label5.Size = new Size(95, 27);
            label5.TabIndex = 17;
            label5.Text = "密码";
            // 
            // input_password
            // 
            input_password.Font = new Font("Microsoft YaHei UI", 10F);
            input_password.Location = new Point(31, 331);
            input_password.Name = "input_password";
            input_password.PasswordChar = '*';
            input_password.PlaceholderText = "数据库密码";
            input_password.PrefixSvg = resources.GetString("input_password.PrefixSvg");
            input_password.Size = new Size(600, 40);
            input_password.SuffixText = "";
            input_password.TabIndex = 16;
            // 
            // button_test
            // 
            button_test.Font = new Font("Microsoft YaHei UI", 10F);
            button_test.ImageSvg = resources.GetString("button_test.ImageSvg");
            button_test.Location = new Point(36, 538);
            button_test.Name = "button_test";
            button_test.Size = new Size(130, 45);
            button_test.TabIndex = 18;
            button_test.Text = "测试连接";
            button_test.Type = AntdUI.TTypeMini.Warn;
            button_test.Click += button_test_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft YaHei UI", 10F);
            label2.Location = new Point(36, 379);
            label2.Name = "label2";
            label2.Size = new Size(95, 27);
            label2.TabIndex = 20;
            label2.Text = "数据库";
            // 
            // select_database
            // 
            select_database.JoinRight = true;
            select_database.Location = new Point(30, 412);
            select_database.Name = "select_database";
            select_database.PlaceholderText = "数据库";
            select_database.PrefixSvg = resources.GetString("select_database.PrefixSvg");
            select_database.Size = new Size(540, 40);
            select_database.TabIndex = 21;
            // 
            // badge_status
            // 
            badge_status.Location = new Point(36, 471);
            badge_status.Name = "badge_status";
            badge_status.Size = new Size(594, 27);
            badge_status.TabIndex = 22;
            badge_status.Text = "未开始";
            badge_status.Visible = false;
            // 
            // button_getDatabases
            // 
            button_getDatabases.ImageSvg = resources.GetString("button_getDatabases.ImageSvg");
            button_getDatabases.JoinLeft = true;
            button_getDatabases.Location = new Point(572, 412);
            button_getDatabases.Name = "button_getDatabases";
            button_getDatabases.Size = new Size(56, 40);
            button_getDatabases.TabIndex = 23;
            button_getDatabases.Type = AntdUI.TTypeMini.Primary;
            button_getDatabases.Click += button_getDatabases_Click;
            // 
            // progress_db
            // 
            progress_db.Font = new Font("Microsoft YaHei UI Light", 16F);
            progress_db.Loading = true;
            progress_db.Location = new Point(235, 504);
            progress_db.Name = "progress_db";
            progress_db.Radius = 5;
            progress_db.Shape = AntdUI.TShape.Circle;
            progress_db.Size = new Size(192, 213);
            progress_db.TabIndex = 24;
            progress_db.Text = "0%";
            // 
            // button_github
            // 
            button_github.AutoSizeMode = AntdUI.TAutoSize.Auto;
            button_github.Dock = DockStyle.Bottom;
            button_github.Font = new Font("Microsoft YaHei UI", 16F);
            button_github.ImageSvg = resources.GetString("button_github.ImageSvg");
            button_github.Location = new Point(0, 676);
            button_github.Name = "button_github";
            button_github.Shape = AntdUI.TShape.Circle;
            button_github.Size = new Size(67, 67);
            button_github.TabIndex = 26;
            button_github.Click += button_github_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(659, 743);
            Controls.Add(button_github);
            Controls.Add(progress_db);
            Controls.Add(button_getDatabases);
            Controls.Add(badge_status);
            Controls.Add(select_database);
            Controls.Add(label2);
            Controls.Add(button_test);
            Controls.Add(label5);
            Controls.Add(input_password);
            Controls.Add(label4);
            Controls.Add(input_username);
            Controls.Add(input_port);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button_recover);
            Controls.Add(button_backup);
            Controls.Add(input_host);
            Controls.Add(windowBar1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MYSQL数据迁移";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.WindowBar windowBar1;
        private AntdUI.Input input_host;
        private AntdUI.Button button_backup;
        private AntdUI.Button button_recover;
        private AntdUI.Label label1;
        private AntdUI.Label label3;
        private AntdUI.InputNumber input_port;
        private AntdUI.Label label4;
        private AntdUI.Input input_username;
        private AntdUI.Label label5;
        private AntdUI.Input input_password;
        private AntdUI.Button button_test;
        private AntdUI.Label label2;
        private AntdUI.Select select_database;
        private AntdUI.Badge badge_status;
        private AntdUI.Button button_getDatabases;
        private AntdUI.Progress progress_db;
        private AntdUI.Button button_github;
    }
}
