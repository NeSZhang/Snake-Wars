using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_Wars
{
    class Map : Circle
    {
        #region 初始化
        public Map()
        {

        }
        public Map(int xRows, int yRows, Color color) : base(xRows, yRows, color)
        {

        }
        public Map(Circle obj, Color color)
        {
            XRow = obj.XRow;
            YRow = obj.YRow;
            Control = obj.Control;
            Color = color;
            Control.BackColor = color;
        }
        #endregion

        #region 绘制地图
        public void DrawMap(int xRows, int yRows, Circle[,] data, int bWidth, int bHeight, Panel pa)
        {
            for (int i = 0; i < xRows; i++)     //行
            {
                for (int j = 0; j < yRows; j++)    //列
                {
                    data[i, j] = new Circle(i, j, Color);
                    data[i, j].Control.Size = new Size(bWidth, bHeight);
                    data[i, j].Control.Location = new Point(j * bWidth, i * bHeight);
                    pa.Controls.Add(data[i, j].Control);
                }
            }
        }
        #endregion
    }
}
