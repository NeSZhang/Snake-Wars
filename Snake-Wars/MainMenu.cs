using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Wars
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        #region 点击事件
        private void label1_Click(object sender, EventArgs e)   //游戏介绍
        {

        }

        private void Ranking_Click(object sender, EventArgs e)  //排行榜
        {

        }

        private void Rules_Click(object sender, EventArgs e)    //规则
        {

        }
        #endregion

        #region 按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
