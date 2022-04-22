using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunouPlugin
{
    public partial class SettingForm : Form
    {
        MunouPlugin parent;
        public SettingForm(MunouPlugin panret)
        {
            this.parent = panret;
            InitializeComponent();
        }

        private void bt_Test_Click(object sender, EventArgs e)
        {
            parent.SendMsg("テスト");
        }

        private void chk_SayName_CheckedChanged(object sender, EventArgs e)
        {
            parent.readName = chk_SayName.Checked;
        }
    }
}
