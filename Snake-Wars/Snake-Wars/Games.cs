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
        SoundPlayer gaming;
        SoundPlayer vitory;
        SoundPlayer defeat;         //音频

        Game game;
        public int screennum;       //难度等级
        public int Scores;          //分数
        public bool isStart;        //是否开始
        public bool isExsit;        //默认没点击退出按钮
        public bool isFinished;     //判断当前关卡是否结束
        public bool Return;         //返回主界面

        #region 初始化
        public Games()
        {
            isStart = false;
            screennum = 1;
            isExsit = false;
            isFinished = false;
            Return = false;
            InitializeComponent();
            game = new Game(panel1); //panel中运行游戏
            Target(screennum);
        }

        private void Games_Load(object sender, EventArgs e)//加载音频
        {
            gaming = new SoundPlayer();
            gaming.SoundLocation = Application.StartupPath + "\\" + "resources" + "\\" + "gaming.wav";
            vitory = new SoundPlayer();
            vitory.SoundLocation = Application.StartupPath + "\\" + "resources" + "\\" + "victory.wav";
            defeat = new SoundPlayer();
            defeat.SoundLocation = Application.StartupPath + "\\" + "resources" + "\\" + "defeat.wav";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//获取键盘事件
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
                gaming.Stop();
                //game.Gameover();
                timer1.Enabled = false;
                vitory.Play();
                MessageBox.Show("恭喜！闯关成功！");
                isFinished = true;
            }
            if (isFinished != true && game.defeated == true)
            {
                gaming.Stop();
                pictureBox1.Visible = true;
                defeat.Play();
                isFinished = true;

                if (MessageBox.Show("确认退出？", "退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormHelper.GameClose2 = true;   //返回主页面
                    Close();
                }
                else
                {
                    FormHelper.GameClose1 = true;   //重新开窗体
                    Close();
                }
            }
        }
        #endregion

        #region 按钮事件
        private void button1_Click(object sender, EventArgs e)//开始、暂停
        {
            if (!isStart && !Return)
            {
                game.Start(600 - (screennum - 1) * 30); //速度
                isStart = true;
                button1.Text = "暂停";
                gaming.Load();
                gaming.PlayLooping();
            }
            else if (!Return)
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
            Return = true;
            button1_Click(sender, e);
            if (MessageBox.Show("确认退出？", "退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            Return = true;
            button1_Click(sender, e);
            if (MessageBox.Show("确认退出？", "返回主菜单", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Return)
                    game.Gameover();
                defeat.Play();
                Close();
                HomePage menu = new HomePage();
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
