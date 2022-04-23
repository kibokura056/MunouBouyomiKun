using System;
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
            chk_SayName.Checked = parent.readName;
            chk_SuperchatOnly.Checked = parent.superchatOnly;
        }

        private void bt_Test_Click(object sender, EventArgs e)
        {
            parent.SendMsg("テスト");
        }

        private void chk_SayName_CheckedChanged(object sender, EventArgs e)
        {
            parent.readName = chk_SayName.Checked;
        }

        private void chk_SuperchatOnly_CheckedChanged(object sender, EventArgs e)
        {
            parent.superchatOnly = chk_SuperchatOnly.Checked;
        }
    }
}
