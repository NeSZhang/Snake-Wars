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
    public partial class HomePage : Form
    {
        public string username;
        public string pwd;
        //连接数据库
        private string connectSql = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public HomePage()
        {
            InitializeComponent();
        }

        #region 点击事件
        private void label1_Click(object sender, EventArgs e)   //游戏介绍
        {
            string str = "贪吃蛇游戏是一款风靡全球的休闲益智类游戏，既简单又耐玩。";
            MessageBox.Show(str, "游戏介绍");
        }

        private void Ranking_Click(object sender, EventArgs e)  //排行榜
        {
            MessageBox.Show("待开发......", "排行榜");
        }

        private void Rules_Click(object sender, EventArgs e)    //规则
        {
            string str = "贪吃蛇的唯一的目标就是长成最长的一条蛇！\n" +
                "键盘上下左右控制小蛇走位，吃掉地图上的食物就会变长。\n" +
                "达到一定分数即可进入下一关。";
            MessageBox.Show(str, "游戏规则");
        }
        #endregion

        #region 按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出？", "退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Environment.Exit(0); 
            }
        }

        #endregion
    }
}
