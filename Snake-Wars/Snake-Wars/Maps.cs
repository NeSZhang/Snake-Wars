using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Maps : Circle
    {
        public Maps()
        {

        }
        public Maps(int rows, int cols, Color color) : base(rows, cols, color)
        {

        }
        public Maps(Circle obj, Color color)
        {
            this.XRow = obj.XRow;
            this.YRow = obj.YRow;
            this.Label = obj.Label;
            this.Color = color;
            this.Label.BackColor = color;
        }

        public void DrawMap(int xRows, int yRows, Circle[,] circles, int bWidth, int bHeight, Panel pa)
        {
            for (int x = 0; x < xRows; x++)      //行
            {
                for (int y = 0; y < yRows; y++)    //列
                {
                    circles[x, y] = new Circle(x, y, this.Color);
                    circles[x, y].Label.Size = new Size(bWidth, bHeight);
                    circles[x, y].Label.Location = new Point(x * bWidth, y * bHeight);
                    pa.Controls.Add(circles[x, y].Label);
                }
            }
        }
    }
}
