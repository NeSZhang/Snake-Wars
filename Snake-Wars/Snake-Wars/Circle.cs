using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Circle
    {
        private int xRows;//行
        private int yCols;//列
        private Color color;//颜色

        #region 属性
        public int XRow { get => xRows; set => xRows = value; }
        public int YRow { get => yCols; set => yCols = value; }
        public Color Color { get => color; set => color = value; }
        #endregion

        public Circle(int xRows, int yRows, Color c) //初始化
        {
            this.xRows = xRows;
            this.yCols = yRows;
            this.color = c;
            //this.la = new Label();
            //this.la.BackColor = bg;

        }

        public Circle() //初始化
        {
        }
    }
}
