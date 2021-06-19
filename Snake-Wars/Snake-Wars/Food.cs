using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_Wars
{
    class Food : Blocks
    {
        #region 初始化
        public Food()
        {
        }

        public Food(Blocks obj, Color food)
        {
            this.XRow = obj.XRow;
            this.YRow = obj.YRow;
            this.Control = obj.Control;
            this.Color = food;
            this.Control.BackColor = food;
        }
        #endregion

        #region 画食物
        public void DrawFood(Blocks[,] data, int xRows, int yRows)
        {
            Random rand = new Random();   //随机生成的类进行实例化
            int x, y;
            do
            {
                x = rand.Next(xRows - 1);
                y = rand.Next(yRows - 1);
            }
            while ((data[x, y] is Snake));
            data[x, y] = new Food(data[x, y], Color);
        }
        #endregion
    }
}
