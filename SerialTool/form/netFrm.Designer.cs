
namespace SerialTool
{
    partial class netFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxSendAndRecive = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlAccept = new System.Windows.Forms.Panel();
            this.btnAcClear = new System.Windows.Forms.Button();
            this.txtAccept = new System.Windows.Forms.TextBox();
            this.lblAccept = new System.Windows.Forms.Label();
            this.pnlSend = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSeClear = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.gbxPort = new System.Windows.Forms.GroupBox();
            this.btnStar = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.gbxClient = new System.Windows.Forms.GroupBox();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxSendAndRecive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlAccept.SuspendLayout();
            this.pnlSend.SuspendLayout();
            this.gbxPort.SuspendLayout();
            this.gbxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSendAndRecive
            // 
            this.gbxSendAndRecive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSendAndRecive.Controls.Add(this.splitContainer1);
            this.gbxSendAndRecive.Location = new System.Drawing.Point(183, 12);
            this.gbxSendAndRecive.Name = "gbxSendAndRecive";
            this.gbxSendAndRecive.Size = new System.Drawing.Size(735, 587);
            this.gbxSendAndRecive.TabIndex = 2;
            this.gbxSendAndRecive.TabStop = false;
            this.gbxSendAndRecive.Text = "收发区";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlAccept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlSend);
            this.splitContainer1.Size = new System.Drawing.Size(729, 567);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlAccept
            // 
            this.pnlAccept.Controls.Add(this.btnAcClear);
            this.pnlAccept.Controls.Add(this.txtAccept);
            this.pnlAccept.Controls.Add(this.lblAccept);
            this.pnlAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccept.Location = new System.Drawing.Point(0, 0);
            this.pnlAccept.Name = "pnlAccept";
            this.pnlAccept.Size = new System.Drawing.Size(729, 417);
            this.pnlAccept.TabIndex = 0;
            // 
            // btnAcClear
            // 
            this.btnAcClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcClear.Location = new System.Drawing.Point(676, 3);
            this.btnAcClear.Name = "btnAcClear";
            this.btnAcClear.Size = new System.Drawing.Size(50, 23);
            this.btnAcClear.TabIndex = 2;
            this.btnAcClear.Text = "清除";
            this.btnAcClear.UseVisualStyleBackColor = true;
            this.btnAcClear.Click += new System.EventHandler(this.btnAcClear_Click);
            // 
            // txtAccept
            // 
            this.txtAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccept.BackColor = System.Drawing.SystemColors.Window;
            this.txtAccept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccept.Location = new System.Drawing.Point(5, 29);
            this.txtAccept.Multiline = true;
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccept.Size = new System.Drawing.Size(721, 385);
            this.txtAccept.TabIndex = 1;
            // 
            // lblAccept
            // 
            this.lblAccept.AutoSize = true;
            this.lblAccept.Location = new System.Drawing.Point(3, 14);
            this.lblAccept.Name = "lblAccept";
            this.lblAccept.Size = new System.Drawing.Size(29, 12);
            this.lblAccept.TabIndex = 0;
            this.lblAccept.Text = "接收";
            // 
            // pnlSend
            // 
            this.pnlSend.Controls.Add(this.btnSend);
            this.pnlSend.Controls.Add(this.btnSeClear);
            this.pnlSend.Controls.Add(this.txtSend);
            this.pnlSend.Controls.Add(this.lblSend);
            this.pnlSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSend.Location = new System.Drawing.Point(0, 0);
            this.pnlSend.Name = "pnlSend";
            this.pnlSend.Size = new System.Drawing.Size(729, 146);
            this.pnlSend.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(660, 108);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(65, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSeClear
            // 
            this.btnSeClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeClear.Location = new System.Drawing.Point(676, 5);
            this.btnSeClear.Name = "btnSeClear";
            this.btnSeClear.Size = new System.Drawing.Size(49, 23);
            this.btnSeClear.TabIndex = 3;
            this.btnSeClear.Text = "清除";
            this.btnSeClear.UseVisualStyleBackColor = true;
            this.btnSeClear.Click += new System.EventHandler(this.btnSeClear_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(4, 31);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(721, 71);
            this.txtSend.TabIndex = 2;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(3, 16);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(29, 12);
            this.lblSend.TabIndex = 0;
            this.lblSend.Text = "发送";
            // 
            // gbxPort
            // 
            this.gbxPort.Controls.Add(this.btnStar);
            this.gbxPort.Controls.Add(this.txtPort);
            this.gbxPort.Controls.Add(this.lblPort);
            this.gbxPort.Controls.Add(this.txtIp);
            this.gbxPort.Controls.Add(this.lblIp);
            this.gbxPort.Controls.Add(this.cboProtocol);
            this.gbxPort.Controls.Add(this.lblProtocol);
            this.gbxPort.Location = new System.Drawing.Point(10, 12);
            this.gbxPort.Name = "gbxPort";
            this.gbxPort.Size = new System.Drawing.Size(167, 222);
            this.gbxPort.TabIndex = 3;
            this.gbxPort.TabStop = false;
            this.gbxPort.Text = "端口设置";
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(56, 193);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(105, 23);
            this.btnStar.TabIndex = 6;
            this.btnStar.Text = "打开";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnOpenOrClose_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(8, 139);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(153, 21);
            this.txtPort.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 123);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 12);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "端口号";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(8, 90);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(153, 21);
            this.txtIp.TabIndex = 3;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(6, 74);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(41, 12);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "IP地址";
            // 
            // cboProtocol
            // 
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboProtocol.Items.AddRange(new object[] {
            "TCP Server",
            "TCP Client",
            "UDP"});
            this.cboProtocol.Location = new System.Drawing.Point(8, 41);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(153, 20);
            this.cboProtocol.TabIndex = 1;
            this.cboProtocol.SelectedIndexChanged += new System.EventHandler(this.cboProtocol_SelectedIndexChanged);
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(6, 25);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(53, 12);
            this.lblProtocol.TabIndex = 0;
            this.lblProtocol.Text = "协议类型";
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(this.cboClient);
            this.gbxClient.Controls.Add(this.btnClose);
            this.gbxClient.Enabled = false;
            this.gbxClient.Location = new System.Drawing.Point(10, 240);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(161, 81);
            this.gbxClient.TabIndex = 4;
            this.gbxClient.TabStop = false;
            this.gbxClient.Text = "客服端";
            this.gbxClient.Visible = false;
            // 
            // cboClient
            // 
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Items.AddRange(new object[] {
            "All Clients"});
            this.cboClient.Location = new System.Drawing.Point(6, 24);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(149, 20);
            this.cboClient.TabIndex = 1;
            this.cboClient.Text = "All Clients";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(6, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "断开";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // netFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 602);
            this.Controls.Add(this.gbxClient);
            this.Controls.Add(this.gbxPort);
            this.Controls.Add(this.gbxSendAndRecive);
            this.Name = "netFrm";
            this.Text = "网络工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.netFrm_FormClosing);
            this.gbxSendAndRecive.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlAccept.ResumeLayout(false);
            this.pnlAccept.PerformLayout();
            this.pnlSend.ResumeLayout(false);
            this.pnlSend.PerformLayout();
            this.gbxPort.ResumeLayout(false);
            this.gbxPort.PerformLayout();
            this.gbxClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSendAndRecive;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlAccept;
        private System.Windows.Forms.Button btnAcClear;
        private System.Windows.Forms.TextBox txtAccept;
        private System.Windows.Forms.Label lblAccept;
        private System.Windows.Forms.Panel pnlSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSeClear;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.GroupBox gbxPort;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Button btnClose;
    }
}