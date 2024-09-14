
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
            this.SerialTool = new System.Windows.Forms.ToolStripMenuItem();
            this.NetTool = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFrm = new System.Windows.Forms.Panel();
            this.MeterTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialTool,
            this.NetTool,
            this.MeterTool});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SerialTool
            // 
            this.SerialTool.Name = "SerialTool";
            this.SerialTool.Size = new System.Drawing.Size(92, 21);
            this.SerialTool.Text = "串口通信工具";
            this.SerialTool.Click += new System.EventHandler(this.SerialTool_Click);
            // 
            // NetTool
            // 
            this.NetTool.Name = "NetTool";
            this.NetTool.Size = new System.Drawing.Size(92, 21);
            this.NetTool.Text = "网络通信工具";
            this.NetTool.Click += new System.EventHandler(this.NetTool_Click);
            // 
            // pnlFrm
            // 
            this.pnlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrm.Location = new System.Drawing.Point(0, 25);
            this.pnlFrm.Name = "pnlFrm";
            this.pnlFrm.Size = new System.Drawing.Size(919, 615);
            this.pnlFrm.TabIndex = 1;
            // 
            // MeterTool
            // 
            this.MeterTool.Name = "MeterTool";
            this.MeterTool.Size = new System.Drawing.Size(80, 21);
            this.MeterTool.Text = "电表上位机";
            this.MeterTool.Click += new System.EventHandler(this.MeterTool_Click);
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
            this.Text = "通信工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SerialTool;
        private System.Windows.Forms.ToolStripMenuItem NetTool;
        private System.Windows.Forms.Panel pnlFrm;
        private System.Windows.Forms.ToolStripMenuItem MeterTool;
    }
}