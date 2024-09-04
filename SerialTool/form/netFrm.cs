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
    public partial class netFrm : Form
    {
        public netFrm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenOrClose_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "关闭连接")
            {
                btnConnect.Text = "建立连接";
            }
            else
            {
                btnConnect.Text = "关闭连接";
            }

        }
    }
}
