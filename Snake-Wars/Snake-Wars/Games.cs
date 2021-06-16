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
    public partial class Games : Form
    {
        Game game;
        public int screennum = 1;          //定义难度等级
        public int Scores;                 //定义分数
        public bool isExsit = false;       //默认没点击退出按钮
        public bool IsFinish = false;      //判断当前关卡是否结束
        public bool ClickReturn = false;     //返回主界面
        public Games()
        {
            InitializeComponent();
            game = new Game(this.panel1); //panel中运行游戏
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)  //暂停或继续
                timer1.Enabled = !timer1.Enabled;   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = new CreateGraphics();
            //SolidBrush brush = new SolidBrush(color);
            //g.FillEllipse(brush, new Rectangle(xRows, yCols, xRows + 15, yCols + 15));
        }
    }
}
