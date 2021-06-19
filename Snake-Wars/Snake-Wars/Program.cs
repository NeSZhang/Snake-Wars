using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Wars
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomePage());

            if (FormHelper.LoginClose)
            {
                Application.Run(new Games());
            }
            if (FormHelper.GameClose1)
            {
                Application.Run(new Games());
            }
            if (FormHelper.GameClose2)
            {
                Application.Run(new HomePage());
            }
        }
    }
    public class FormHelper
    {
        public static bool LoginClose = false;//打开新游戏
        public static bool GameClose1 = false;//打开新游戏
        public static bool GameClose2 = false;//打开主窗体
    }
}
