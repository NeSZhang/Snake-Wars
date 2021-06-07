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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                //复选框被勾选，明文显示
                passwordBox1.PasswordChar = new char();
            else
                //复选框被取消勾选，密文显示
                passwordBox1.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                //复选框被勾选，明文显示
                passwordBox2.PasswordChar = new char();
            else
                //复选框被取消勾选，密文显示
                passwordBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
