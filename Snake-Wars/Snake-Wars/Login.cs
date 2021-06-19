using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public string username;
        public string pwd;
        //连接数据库
        private string connectSql = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        bool pass;//通过登录
        bool init;//判断字符
        bool LorR;//登录或注册
        HomePage home;//控制上一窗体

        #region 初始化
        public Login()
        {
            LorR = true;    //默认是登录状态 false是注册状态
            pass = false;   //默认未通过登录
            init = false;   //判断是否输入了字符串
            InitializeComponent();
        }
        public Login(HomePage home)
        {
            LorR = true;    //默认是登录状态 false是注册状态
            pass = false;   //默认未通过登录
            init = false;   //判断是否输入了字符串
            this.home = home;
            InitializeComponent();
        }
        #endregion

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
        private void textBox1_TextChanged(object sender, EventArgs e)       //账号
        {
            init = true;
            Regex regNum = new Regex("^[0 - 9] *$");    //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.@?`_]");        //验证是否是合法字符
            if (!init && !regNum.IsMatch(textBox1.Text.Trim())
                && !regNum.IsMatch(textBox1.Text.Trim())
                && !regLetter.IsMatch(textBox1.Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            init = false;
        }
        private void passwordBox_TextChanged(object sender, EventArgs e)    //密码
        {
            init = true;
            passwordBox.PasswordChar = '*';
            Regex regNum = new Regex("^[0-9]*$");        //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.-@?`_]");       //验证是否是合法字符
            if (!init && !regExp.IsMatch(passwordBox.Text.Trim())
                && !regNum.IsMatch(passwordBox.Text.Trim())
                && !regLetter.IsMatch(Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                passwordBox.Text = passwordBox.Text.Substring(0, passwordBox.Text.Length - 1);
            }
            init = false;
        }
        private void passwordBox2_TextChanged(object sender, EventArgs e)   //确认密码
        {
            init = true;
            passwordBox2.PasswordChar = '*';
            Regex regNum = new Regex("^[0-9]*$");        //验证是否是数字
            Regex regLetter = new Regex("[a-zA-Z]");    //验证是否是字母
            Regex regExp = new Regex("[.-@?`_]");       //验证是否是合法字符
            if (!init && !regExp.IsMatch(passwordBox2.Text.Trim())
                && !regNum.IsMatch(passwordBox2.Text.Trim())
                && !regLetter.IsMatch(passwordBox2.Text.Trim()))
            {
                MessageBox.Show("非法字符，请重新输入！");
                passwordBox2.Text = passwordBox2.Text.Substring(0, passwordBox2.Text.Length - 1);
            }
            init = false;
        }
        #endregion

        #region 按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (LorR)   //登录
            {
                Login_in();
                if (pass)
                {
                    Close();
                    home.Close();
                    FormHelper.LoginClose = true;//进入游戏界面
                }
            }
            else        //注册
                newRegister();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (LorR)       //登录
            {
                Close();    //返回主页面
            }
            else            //注册
            {
                ChangeMode();   //回到登录界面
            }
        }
        #endregion

        private void ChangeMode()    //登录or注册
        {
            if (LorR)   //登录时点击
            {
                Text = "注册账号";
                Register.Visible = false;
                ConfirmPwd.Visible = true;
                passwordBox2.Visible = true;
                checkBox2.Visible = true;
                label3.Text = "请输入您的账号密码并确认密码：";
                button1.Text = "注册";
                LorR = false;
            }
            else        //注册时点击
            {
                Text = "登录";
                Register.Visible = true;
                ConfirmPwd.Visible = false;
                passwordBox2.Visible = false;
                checkBox2.Visible = false;
                label3.Text = "请输入您的账号密码：";
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

        #region 数据库操作
        private void Login_in()//登录
        {
            //连接数据库对比账号密码是否正确
            string username = textBox1.Text.Trim();//用户名
            string password = passwordBox.Text.Trim();//密码

            //定义SQL查询语句:用户名 密码
            string sql = "select * from Users where username='" + username + "' and password='" + password + "'";

            SqlConnection con = new SqlConnection(connectSql);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);//对数据库执行一个SQL语句或存储过程              
            SqlDataReader sread = com.ExecuteReader();//提供一种读取数据库行的方式

            if (sread.Read())
            {
                this.username = sread["username"].ToString();
                this.pwd = sread["password"].ToString();
                MessageBox.Show("登录成功", "登录");
                pass = true;
            }
            else if (textBox1.Text == String.Empty)
                MessageBox.Show("请输入账号");
            else if (passwordBox.Text == String.Empty)
                MessageBox.Show("请输入密码");
            else
            {
                MessageBox.Show("请输入正确的用户名和密码");
                passwordBox.Text = "";
            }
        }
        private void newRegister()//注册
        {
            //注册账号写入数据库
            string username = textBox1.Text.Trim();//用户名
            string password = passwordBox.Text.Trim();//密码
            string confimpwd = passwordBox2.Text.Trim();//确认密码

            string consqlserver = "Data Source=.;Initial Catalog=Cuser;Integrated Security=True;";
            SqlConnection con = new SqlConnection(consqlserver);
            con.Open();

            //查找用户名是否存在
            string sql = String.Format("select loginname from userinformation where loginname = '{0}'", username);
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader datareader = command.ExecuteReader();
            int i = 0;
            for (i = 0; datareader.Read(); i++) { }
            if (i > 0)  //已注册
            {
                MessageBox.Show("用户名已存在！", "提示");
                datareader.Close();
            }
            else    //注册
            {
                string sql1 = String.Format("insert into userinformation(loginname,password,grade) values('{0}','{1}','{2}')", username, password, 0);
                SqlCommand command1 = new SqlCommand(sql1, con);
                datareader.Close();
                //
                if (textBox1.Text == String.Empty)
                    MessageBox.Show("请输入账号");
                else if (passwordBox.Text == String.Empty)
                    MessageBox.Show("请输入密码");
                else if (passwordBox.Text != passwordBox2.Text)   //检查两次输入是否一致
                {
                    MessageBox.Show("两次输入密码不一致，请重新输入！");
                    passwordBox.Text = "";
                    passwordBox2.Text = "";
                }
                else
                {
                    int j = command1.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show("注册成功！已自动登录！", "登录");
                    pass = true;
                    this.username = username;
                    this.pwd = password;
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                }
            }
            con.Close();
        }
        #endregion
    }
}
