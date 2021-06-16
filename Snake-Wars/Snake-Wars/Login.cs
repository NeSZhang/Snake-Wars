using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Wars
{
    public partial class Login : Form
    {
        bool LorR;

        public Login()
        {
            LorR = true;
            InitializeComponent();
        }


        private void Register_Click(object sender, EventArgs e)
        {
            ChangeMode();
        }

        #region 密码明文切换
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                passwordBox.PasswordChar = new char();  //复选框被勾选，明文显示
            else    
                passwordBox.PasswordChar = '*';         //复选框被取消勾选，密文显示
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                passwordBox2.PasswordChar = new char();  //复选框被勾选，明文显示
            else
                passwordBox2.PasswordChar = '*';         //复选框被取消勾选，密文显示
        }
        #endregion

        #region 判断字符是否合法
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
            Regex regNum = new Regex("^[0-9]*$");        //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.-@?`_]");       //验证是否是合法字符
            if (regExp.IsMatch(Text.Trim()) || regNum.IsMatch(Text.Trim())
                || regLetter.IsMatch(Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                Text = Text.Substring(0, Text.Length - 1);
            }
        }
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
            Regex regNum= new Regex("^[0-9]*$");        //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.-@?`_]");       //验证是否是合法字符
            if (regExp.IsMatch(Text.Trim()) || regNum.IsMatch(Text.Trim())
                || regLetter.IsMatch(Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                Text = Text.Substring(0, Text.Length - 1);
            }
        }
        private void passwordBox2_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
            Regex regNum = new Regex("^[0-9]*$");        //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.-@?`_]");       //验证是否是合法字符
            if (regExp.IsMatch(Text.Trim()) || regNum.IsMatch(Text.Trim())
                || regLetter.IsMatch(Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                Text = Text.Substring(0, Text.Length - 1);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (LorR)   //登录
            {
                //连接数据库对比账号密码是否正确

            }
            else        //注册
            {
                //注册账号写入数据库

                //比较两次输入的密码是否一致

            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (LorR)   //登录
            {
                this.Close();
                                //返回主页面


            }
            else        //注册
            {
                ChangeMode();   //回到登录界面
            }
        }
        private void ChangeMode()       //登录or注册
        {
            if (LorR)   //登录时点击
            {
                this.Text = "注册账号";
                Register.Visible = false;
                ConfirmPwd.Visible = true;
                passwordBox2.Visible = true;
                checkBox2.Visible = true;
                button1.Text = "注册";
                LorR = false;
            }
            else        //注册时点击
            {
                this.Text = "登录";
                Register.Visible = true;
                ConfirmPwd.Visible = false;
                passwordBox2.Visible = false;
                checkBox2.Visible = false;
                button1.Text = "登录";
                LorR = true;
            }
        }

        #region 回车事件
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void passwordBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        #endregion


    }
}
