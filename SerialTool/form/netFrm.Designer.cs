
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
            this.lblMs = new System.Windows.Forms.Label();
            this.tbxTI = new System.Windows.Forms.TextBox();
            this.chkAutoSend = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSeClear = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.gbxPort = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.gbxSendAndRecive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlAccept.SuspendLayout();
            this.pnlSend.SuspendLayout();
            this.gbxPort.SuspendLayout();
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
            this.pnlSend.Controls.Add(this.lblMs);
            this.pnlSend.Controls.Add(this.tbxTI);
            this.pnlSend.Controls.Add(this.chkAutoSend);
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
            // lblMs
            // 
            this.lblMs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMs.Location = new System.Drawing.Point(145, 119);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(105, 14);
            this.lblMs.TabIndex = 7;
            this.lblMs.Text = "ms(最低100ms)";
            // 
            // tbxTI
            // 
            this.tbxTI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxTI.Location = new System.Drawing.Point(81, 115);
            this.tbxTI.Name = "tbxTI";
            this.tbxTI.Size = new System.Drawing.Size(58, 21);
            this.tbxTI.TabIndex = 6;
            // 
            // chkAutoSend
            // 
            this.chkAutoSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoSend.AutoSize = true;
            this.chkAutoSend.Location = new System.Drawing.Point(3, 120);
            this.chkAutoSend.Name = "chkAutoSend";
            this.chkAutoSend.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSend.TabIndex = 5;
            this.chkAutoSend.Text = "自动发送";
            this.chkAutoSend.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(650, 104);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
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
            this.txtSend.Size = new System.Drawing.Size(721, 67);
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
            this.gbxPort.Controls.Add(this.btnConnect);
            this.gbxPort.Controls.Add(this.txtServerPort);
            this.gbxPort.Controls.Add(this.lblServerPort);
            this.gbxPort.Controls.Add(this.txtServerIp);
            this.gbxPort.Controls.Add(this.lblServerIp);
            this.gbxPort.Controls.Add(this.cboProtocol);
            this.gbxPort.Controls.Add(this.lblProtocol);
            this.gbxPort.Location = new System.Drawing.Point(10, 12);
            this.gbxPort.Name = "gbxPort";
            this.gbxPort.Size = new System.Drawing.Size(167, 222);
            this.gbxPort.TabIndex = 3;
            this.gbxPort.TabStop = false;
            this.gbxPort.Text = "端口设置";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(56, 193);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "打开连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnOpenOrClose_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(8, 139);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(153, 21);
            this.txtServerPort.TabIndex = 5;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(6, 123);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(77, 12);
            this.lblServerPort.TabIndex = 4;
            this.lblServerPort.Text = "服务器端口号";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(8, 90);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(153, 21);
            this.txtServerIp.TabIndex = 3;
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(6, 74);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(77, 12);
            this.lblServerIp.TabIndex = 2;
            this.lblServerIp.Text = "服务器IP地址";
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
            // netFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 602);
            this.Controls.Add(this.gbxPort);
            this.Controls.Add(this.gbxSendAndRecive);
            this.Name = "netFrm";
            this.Text = "netFrm";
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
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.TextBox tbxTI;
        private System.Windows.Forms.CheckBox chkAutoSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSeClear;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.GroupBox gbxPort;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Button btnConnect;
    }
}