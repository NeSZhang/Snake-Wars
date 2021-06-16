using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Circle
    {
        #region 字段
        private int xRows;          //横向列
        private int yRows;          //纵向行
        private Color color;         //颜色
        private Label label;         //标签控件
        private Point position;      //位置
        #endregion

        #region 属性
        public int XRow { get => xRows; set => xRows = value; }
        public int YRow { get => yRows; set => yRows = value; }
        public Color Color { get => color; set => color = value; }
        public Label Label { get => label; set => label = value; }
        public Point Position { get => position; set => position = value; }
        #endregion

        #region 方法
        public Circle(int xRows, int yRows, Color c) //初始化
        {
            this.xRows = xRows;
            this.yRows = yRows;
            this.color = c;
            this.label = new Label();
            this.position = new Point(xRows, yRows);
            //this.la.BackColor = bg;
        }

        public Circle() //初始化
        {
        }

        #endregion
    }
}
