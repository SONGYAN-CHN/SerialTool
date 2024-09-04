
namespace SerialTool
{
    partial class serialFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxPortSet = new System.Windows.Forms.GroupBox();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboCheck = new System.Windows.Forms.ComboBox();
            this.lbl奇偶校验 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.lbl数据位 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.lbl停止位 = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.lbl波特率 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.lbl端口号 = new System.Windows.Forms.Label();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxFunction = new System.Windows.Forms.GroupBox();
            this.txtTI = new System.Windows.Forms.TextBox();
            this.lblTI = new System.Windows.Forms.Label();
            this.gbxPortSet.SuspendLayout();
            this.gbxSendAndRecive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlAccept.SuspendLayout();
            this.pnlSend.SuspendLayout();
            this.gbxFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPortSet
            // 
            this.gbxPortSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxPortSet.Controls.Add(this.btnClosePort);
            this.gbxPortSet.Controls.Add(this.btnOpenPort);
            this.gbxPortSet.Controls.Add(this.btnRefresh);
            this.gbxPortSet.Controls.Add(this.cboCheck);
            this.gbxPortSet.Controls.Add(this.lbl奇偶校验);
            this.gbxPortSet.Controls.Add(this.cboDataBits);
            this.gbxPortSet.Controls.Add(this.lbl数据位);
            this.gbxPortSet.Controls.Add(this.cboStopBits);
            this.gbxPortSet.Controls.Add(this.lbl停止位);
            this.gbxPortSet.Controls.Add(this.cboBaudRate);
            this.gbxPortSet.Controls.Add(this.lbl波特率);
            this.gbxPortSet.Controls.Add(this.cboPort);
            this.gbxPortSet.Controls.Add(this.lbl端口号);
            this.gbxPortSet.Location = new System.Drawing.Point(12, 12);
            this.gbxPortSet.MinimumSize = new System.Drawing.Size(165, 292);
            this.gbxPortSet.Name = "gbxPortSet";
            this.gbxPortSet.Size = new System.Drawing.Size(165, 292);
            this.gbxPortSet.TabIndex = 0;
            this.gbxPortSet.TabStop = false;
            this.gbxPortSet.Text = "端口设置";
            // 
            // btnClosePort
            // 
            this.btnClosePort.Enabled = false;
            this.btnClosePort.Location = new System.Drawing.Point(8, 261);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(150, 23);
            this.btnClosePort.TabIndex = 12;
            this.btnClosePort.Text = "关 闭 端 口";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenPort.Location = new System.Drawing.Point(8, 235);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(150, 23);
            this.btnOpenPort.TabIndex = 11;
            this.btnOpenPort.Text = "打 开 端 口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 209);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboCheck
            // 
            this.cboCheck.BackColor = System.Drawing.SystemColors.Window;
            this.cboCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheck.FormattingEnabled = true;
            this.cboCheck.Items.AddRange(new object[] {
            "0-无校验",
            "1-偶校验",
            "2-奇校验"});
            this.cboCheck.Location = new System.Drawing.Point(8, 183);
            this.cboCheck.Name = "cboCheck";
            this.cboCheck.Size = new System.Drawing.Size(150, 20);
            this.cboCheck.TabIndex = 9;
            // 
            // lbl奇偶校验
            // 
            this.lbl奇偶校验.AutoSize = true;
            this.lbl奇偶校验.Location = new System.Drawing.Point(7, 169);
            this.lbl奇偶校验.Name = "lbl奇偶校验";
            this.lbl奇偶校验.Size = new System.Drawing.Size(53, 12);
            this.lbl奇偶校验.TabIndex = 8;
            this.lbl奇偶校验.Text = "奇偶校验";
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(8, 107);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(150, 20);
            this.cboDataBits.TabIndex = 7;
            // 
            // lbl数据位
            // 
            this.lbl数据位.AutoSize = true;
            this.lbl数据位.Location = new System.Drawing.Point(6, 93);
            this.lbl数据位.Name = "lbl数据位";
            this.lbl数据位.Size = new System.Drawing.Size(41, 12);
            this.lbl数据位.TabIndex = 6;
            this.lbl数据位.Text = "数据位";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboStopBits.Location = new System.Drawing.Point(8, 145);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(150, 20);
            this.cboStopBits.TabIndex = 5;
            // 
            // lbl停止位
            // 
            this.lbl停止位.AutoSize = true;
            this.lbl停止位.Location = new System.Drawing.Point(5, 131);
            this.lbl停止位.Name = "lbl停止位";
            this.lbl停止位.Size = new System.Drawing.Size(41, 12);
            this.lbl停止位.TabIndex = 4;
            this.lbl停止位.Text = "停止位";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.cboBaudRate.Location = new System.Drawing.Point(8, 69);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(150, 20);
            this.cboBaudRate.TabIndex = 3;
            // 
            // lbl波特率
            // 
            this.lbl波特率.AutoSize = true;
            this.lbl波特率.Location = new System.Drawing.Point(6, 55);
            this.lbl波特率.Name = "lbl波特率";
            this.lbl波特率.Size = new System.Drawing.Size(41, 12);
            this.lbl波特率.TabIndex = 2;
            this.lbl波特率.Text = "波特率";
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(8, 31);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(150, 20);
            this.cboPort.TabIndex = 1;
            // 
            // lbl端口号
            // 
            this.lbl端口号.AutoSize = true;
            this.lbl端口号.Location = new System.Drawing.Point(5, 17);
            this.lbl端口号.Name = "lbl端口号";
            this.lbl端口号.Size = new System.Drawing.Size(41, 12);
            this.lbl端口号.TabIndex = 0;
            this.lbl端口号.Text = "端口号";
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
            this.gbxSendAndRecive.TabIndex = 1;
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
            this.splitContainer1.SplitterDistance = 424;
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
            this.pnlAccept.Size = new System.Drawing.Size(729, 424);
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
            this.txtAccept.Location = new System.Drawing.Point(2, 29);
            this.txtAccept.Multiline = true;
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccept.Size = new System.Drawing.Size(724, 392);
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
            this.pnlSend.Size = new System.Drawing.Size(729, 139);
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
            this.tbxTI.Leave += new System.EventHandler(this.tbxTI_Leave);
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
            this.chkAutoSend.CheckedChanged += new System.EventHandler(this.chkAutoSend_CheckedChanged);
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(6, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxFunction
            // 
            this.gbxFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxFunction.Controls.Add(this.txtTI);
            this.gbxFunction.Controls.Add(this.lblTI);
            this.gbxFunction.Controls.Add(this.btnSave);
            this.gbxFunction.Location = new System.Drawing.Point(12, 310);
            this.gbxFunction.Name = "gbxFunction";
            this.gbxFunction.Size = new System.Drawing.Size(165, 289);
            this.gbxFunction.TabIndex = 2;
            this.gbxFunction.TabStop = false;
            this.gbxFunction.Text = "功能区";
            // 
            // txtTI
            // 
            this.txtTI.Location = new System.Drawing.Point(53, 14);
            this.txtTI.Name = "txtTI";
            this.txtTI.Size = new System.Drawing.Size(58, 21);
            this.txtTI.TabIndex = 10;
            this.txtTI.TextChanged += new System.EventHandler(this.txtTI_TextChanged);
            this.txtTI.Leave += new System.EventHandler(this.txtTI_Leave);
            // 
            // lblTI
            // 
            this.lblTI.AutoSize = true;
            this.lblTI.Location = new System.Drawing.Point(6, 23);
            this.lblTI.Name = "lblTI";
            this.lblTI.Size = new System.Drawing.Size(41, 12);
            this.lblTI.TabIndex = 9;
            this.lblTI.Text = "TI(ms)";
            // 
            // serialFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 602);
            this.Controls.Add(this.gbxFunction);
            this.Controls.Add(this.gbxSendAndRecive);
            this.Controls.Add(this.gbxPortSet);
            this.Name = "serialFrm";
            this.Text = "串口工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbxPortSet.ResumeLayout(false);
            this.gbxPortSet.PerformLayout();
            this.gbxSendAndRecive.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlAccept.ResumeLayout(false);
            this.pnlAccept.PerformLayout();
            this.pnlSend.ResumeLayout(false);
            this.pnlSend.PerformLayout();
            this.gbxFunction.ResumeLayout(false);
            this.gbxFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPortSet;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lbl端口号;
        private System.Windows.Forms.GroupBox gbxSendAndRecive;
        private System.Windows.Forms.ComboBox cboCheck;
        private System.Windows.Forms.Label lbl奇偶校验;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label lbl数据位;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label lbl停止位;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label lbl波特率;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Panel pnlAccept;
        private System.Windows.Forms.TextBox txtAccept;
        private System.Windows.Forms.Label lblAccept;
        private System.Windows.Forms.Button btnSeClear;
        private System.Windows.Forms.Button btnAcClear;
        private System.Windows.Forms.CheckBox chkAutoSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.TextBox tbxTI;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxFunction;
        private System.Windows.Forms.TextBox txtTI;
        private System.Windows.Forms.Label lblTI;
    }
}

