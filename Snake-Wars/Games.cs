using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Wars
{
    public partial class Games : Form
    {
        SoundPlayer gaming = new SoundPlayer(Properties.Resources.ResourceManager.GetString("Gaming"));
        SoundPlayer vitory = new SoundPlayer(Properties.Resources.ResourceManager.GetString("Victory"));
        SoundPlayer defeat = new SoundPlayer(Properties.Resources.ResourceManager.GetString("Defeat"));

        Game game;
        public int screennum = 1;           //定义难度等级
        public int Scores;                  //定义分数
        public bool isStart = false;        //是否开始
        public bool isExsit = false;        //默认没点击退出按钮
        public bool isFinished = false;     //判断当前关卡是否结束
        public bool Return = false;         //返回主界面
        
        #region 初始化
        public Games()
        {
            InitializeComponent();
            game = new Game(panel1); //panel中运行游戏
            Target(screennum);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.ChangeDirections(e.KeyCode);
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)//是否点击键盘
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                e.IsInputKey = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = game.Score.ToString();
            Scores = game.Score;
            if (game.Score >= Convert.ToInt32(label4.Text))
            {
                game.Gameover();
                timer1.Enabled = false;
                vitory.Play();
                MessageBox.Show("恭喜！闯关成功！");
                isFinished = true;
            }
            if (isFinished == true || game.isFinished == true)
                Close();
        }
        #endregion

        #region 按钮事件
        private void button1_Click(object sender, EventArgs e)//开始暂停
        {
            if (!isStart)
            {
                game.Start(600 - (screennum - 1) * 30); //速度
                isStart = true;
                button1.Text = "暂停";
                gaming.Play();
            }
            else
            {
                if (timer1.Enabled)  //暂停或继续
                {
                    timer1.Enabled = !timer1.Enabled;
                    button1.Text = "继续";
                    game.Stop();
                    gaming.Stop();
                }
                else
                {
                    timer1.Enabled = !timer1.Enabled;
                    button1.Text = "暂停";
                    game.Continue();
                    gaming.Play();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            button1_Click(sender, e);
            if (MessageBox.Show("确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                game.Gameover();
                defeat.Play();
                isExsit = true;
                Application.Exit();
            }
            else
                button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)//返回主菜单
        {
            button1_Click(sender, e);
            if (MessageBox.Show("确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                game.Gameover();
                defeat.Play();
                Return = true;
                Close();
                MainMenu menu = new MainMenu();
                menu.Show();
            }
            else
                button1_Click(sender, e);
        }
        #endregion

        public void Target(int screennum)   //获得目标分数
        {
            int sum = 300 + 180 * (screennum - 1);
            label4.Text = sum.ToString();
        }
    }

}
