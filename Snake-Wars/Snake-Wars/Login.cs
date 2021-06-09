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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示
                passwordBox.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                passwordBox.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int Value = (int)textBox1.Text.ToUpper()[20];
            if ("1234567890".IndexOf(textBox1.Text[0]) != -1) this.Text = "数字";
            else if (Value >= (int)'A' && Value <= 'Z') this.Text = "大写字母";
            else if (Value >= (int)'a' && Value <= 'z') this.Text = "小写字母";
            else if (Value == (int)'.' || Value == '-' || Value == '@' || Value == '?' || Value == '`' || Value == '_') this.Text = "特殊字符";
            else this.Text = "非法字符";
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
            int Value = (int)textBox1.Text.ToUpper()[20];
            if ("1234567890".IndexOf(textBox1.Text[0]) != -1) this.Text = "数字";
            else if (Value >= (int)'A' && Value <= 'Z') this.Text = "大写字母";
            else if (Value >= (int)'a' && Value <= 'z') this.Text = "小写字母";
            else if (Value == (int)'.' || Value == '-' || Value == '@' || Value == '?' || Value == '`' || Value == '_') this.Text = "特殊字符";
            else this.Text = "非法字符";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
