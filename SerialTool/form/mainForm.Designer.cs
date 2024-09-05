
namespace SerialTool
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.网络调试助手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFrm = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSerial,
            this.网络调试助手ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSerial
            // 
            this.tsmiSerial.Name = "tsmiSerial";
            this.tsmiSerial.Size = new System.Drawing.Size(68, 21);
            this.tsmiSerial.Text = "串口工具";
            this.tsmiSerial.Click += new System.EventHandler(this.tsmiSerial_Click);
            // 
            // 网络调试助手ToolStripMenuItem
            // 
            this.网络调试助手ToolStripMenuItem.Name = "网络调试助手ToolStripMenuItem";
            this.网络调试助手ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.网络调试助手ToolStripMenuItem.Text = "网络调试助手";
            this.网络调试助手ToolStripMenuItem.Click += new System.EventHandler(this.网络调试助手ToolStripMenuItem_Click);
            // 
            // pnlFrm
            // 
            this.pnlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrm.Location = new System.Drawing.Point(0, 25);
            this.pnlFrm.Name = "pnlFrm";
            this.pnlFrm.Size = new System.Drawing.Size(919, 615);
            this.pnlFrm.TabIndex = 1;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 640);
            this.Controls.Add(this.pnlFrm);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(935, 679);
            this.Name = "mainForm";
            this.Text = "华鹏测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSerial;
        private System.Windows.Forms.ToolStripMenuItem 网络调试助手ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFrm;
    }
}