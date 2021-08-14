
namespace GTAV_Firewall
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_GlobalIPv4 = new System.Windows.Forms.Label();
            this.label_LocalIPv4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.comboBox_Address = new System.Windows.Forms.ComboBox();
            this.button_StartServer = new System.Windows.Forms.Button();
            this.listBox_IP = new System.Windows.Forms.ListBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_SetFirewall = new System.Windows.Forms.Button();
            this.button_ClearFirewall = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_GlobalIPv4);
            this.groupBox1.Controls.Add(this.label_LocalIPv4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP 地址";
            // 
            // label_GlobalIPv4
            // 
            this.label_GlobalIPv4.AutoSize = true;
            this.label_GlobalIPv4.Location = new System.Drawing.Point(75, 45);
            this.label_GlobalIPv4.Name = "label_GlobalIPv4";
            this.label_GlobalIPv4.Size = new System.Drawing.Size(49, 17);
            this.label_GlobalIPv4.TabIndex = 3;
            this.label_GlobalIPv4.Text = "0.0.0.0";
            this.label_GlobalIPv4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label_GlobalIPv4_MouseDoubleClick);
            // 
            // label_LocalIPv4
            // 
            this.label_LocalIPv4.AutoSize = true;
            this.label_LocalIPv4.Location = new System.Drawing.Point(75, 24);
            this.label_LocalIPv4.Name = "label_LocalIPv4";
            this.label_LocalIPv4.Size = new System.Drawing.Size(49, 17);
            this.label_LocalIPv4.TabIndex = 1;
            this.label_LocalIPv4.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "外網地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "區網地址:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Send);
            this.groupBox2.Controls.Add(this.comboBox_Address);
            this.groupBox2.Controls.Add(this.button_StartServer);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "伺服器功能";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(244, 23);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(80, 27);
            this.button_Send.TabIndex = 2;
            this.button_Send.TabStop = false;
            this.button_Send.Text = "發送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // comboBox_Address
            // 
            this.comboBox_Address.FormattingEnabled = true;
            this.comboBox_Address.Items.AddRange(new object[] {
            "ahzol.com",
            "ip.hyyen.com"});
            this.comboBox_Address.Location = new System.Drawing.Point(92, 24);
            this.comboBox_Address.Name = "comboBox_Address";
            this.comboBox_Address.Size = new System.Drawing.Size(146, 25);
            this.comboBox_Address.TabIndex = 1;
            this.comboBox_Address.TabStop = false;
            // 
            // button_StartServer
            // 
            this.button_StartServer.Location = new System.Drawing.Point(6, 23);
            this.button_StartServer.Name = "button_StartServer";
            this.button_StartServer.Size = new System.Drawing.Size(80, 27);
            this.button_StartServer.TabIndex = 0;
            this.button_StartServer.TabStop = false;
            this.button_StartServer.Text = "啟動";
            this.button_StartServer.UseVisualStyleBackColor = true;
            this.button_StartServer.Click += new System.EventHandler(this.button_StartServer_Click);
            // 
            // listBox_IP
            // 
            this.listBox_IP.FormattingEnabled = true;
            this.listBox_IP.ItemHeight = 17;
            this.listBox_IP.Location = new System.Drawing.Point(6, 53);
            this.listBox_IP.Name = "listBox_IP";
            this.listBox_IP.Size = new System.Drawing.Size(146, 191);
            this.listBox_IP.TabIndex = 2;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(6, 23);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(146, 24);
            this.textBox_IP.TabIndex = 3;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(158, 22);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(80, 27);
            this.button_Add.TabIndex = 4;
            this.button_Add.TabStop = false;
            this.button_Add.Text = "加入";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_SetFirewall);
            this.groupBox3.Controls.Add(this.button_ClearFirewall);
            this.groupBox3.Controls.Add(this.label_Status);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button_Delete);
            this.groupBox3.Controls.Add(this.listBox_IP);
            this.groupBox3.Controls.Add(this.button_Add);
            this.groupBox3.Controls.Add(this.textBox_IP);
            this.groupBox3.Location = new System.Drawing.Point(12, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 281);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "防火牆功能";
            // 
            // button_SetFirewall
            // 
            this.button_SetFirewall.Location = new System.Drawing.Point(244, 218);
            this.button_SetFirewall.Name = "button_SetFirewall";
            this.button_SetFirewall.Size = new System.Drawing.Size(80, 27);
            this.button_SetFirewall.TabIndex = 9;
            this.button_SetFirewall.TabStop = false;
            this.button_SetFirewall.Text = "套用";
            this.button_SetFirewall.UseVisualStyleBackColor = true;
            this.button_SetFirewall.Click += new System.EventHandler(this.button_SetFirewall_Click);
            // 
            // button_ClearFirewall
            // 
            this.button_ClearFirewall.Location = new System.Drawing.Point(158, 218);
            this.button_ClearFirewall.Name = "button_ClearFirewall";
            this.button_ClearFirewall.Size = new System.Drawing.Size(80, 27);
            this.button_ClearFirewall.TabIndex = 8;
            this.button_ClearFirewall.TabStop = false;
            this.button_ClearFirewall.Text = "清除";
            this.button_ClearFirewall.UseVisualStyleBackColor = true;
            this.button_ClearFirewall.Click += new System.EventHandler(this.button_ClearFirewall_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(49, 253);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(21, 17);
            this.label_Status.TabIndex = 7;
            this.label_Status.Text = "無";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "狀態:";
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(244, 22);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(80, 27);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.TabStop = false;
            this.button_Delete.Text = "刪除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTAV 防火牆 by sabpprook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_GlobalIPv4;
        private System.Windows.Forms.Label label_LocalIPv4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_StartServer;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.ComboBox comboBox_Address;
        private System.Windows.Forms.ListBox listBox_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_SetFirewall;
        private System.Windows.Forms.Button button_ClearFirewall;
    }
}

