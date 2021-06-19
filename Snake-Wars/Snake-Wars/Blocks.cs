using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake_Wars
{
    class Blocks
    {
        #region 字段
        Label la;      //标签控件
        int xRows;     //行
        int yRows;     //列  
        Color color;   //颜色
        #endregion

        #region 属性
        public int XRow { get => xRows; set => xRows = value; }
        public int YRow { get => yRows; set => yRows = value; }
        public Color Color { get => color; set => color = value; }
        public Label Control
        {
            get => la;
            set
            {
                la = value;
                Color = la.BackColor;
            }
        }
        #endregion

        #region 初始化
        public Blocks()
        {
        }
        public Blocks(int xRows, int yRows, Color color) //初始化方块
        {
            this.xRows = xRows;
            this.yRows = yRows;
            this.color = color;
            this.la = new Label();
            this.la.BackColor = color;
        }
        #endregion
    }
}
