using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTool
{
    public partial class mainForm : Form
    {
        serialFrm serialFrm = new serialFrm();
        netFrm netFrm = new netFrm();
        public mainForm()
        {
            InitializeComponent();
            OpenNewForm(serialFrm);
        }
        /// <summary>
        /// 隐藏控件并展示新窗体控件
        /// </summary>
        /// <param name="newFrm"></param>
        private void OpenNewForm(Form newFrm)
        {
            foreach (Control item in this.pnlFrm.Controls)
            {
                if (item is Form)
                {
                    Form obj = (Form)item;
                    obj.Hide();
                }
            }

            newFrm.TopLevel = false;
            
            newFrm.FormBorderStyle = FormBorderStyle.None;
            newFrm.Parent = this.pnlFrm;
            newFrm.Dock = DockStyle.Fill;
            newFrm.Show();
        }
        private void tsmiSerial_Click(object sender, EventArgs e)
        {
            OpenNewForm(serialFrm);
        }

        private void 网络调试助手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewForm(netFrm);
        }
    }
}
