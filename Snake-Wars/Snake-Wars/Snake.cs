using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_Wars
{
    class Snake : Blocks
    {
        #region 字段
        Point Head;        //头
        List<Snake> Body;  //身
        #endregion

        #region 属性
        public Point Head1 { get => Head; set => Head = value; }
        internal List<Snake> Body1 { get => Body; set => Body = value; }
        #endregion

        #region 初始化
        public Snake()
        {
        }

        public Snake(Blocks obj, Color snake)
        {
            XRow = obj.XRow;
            YRow = obj.YRow;
            Control = obj.Control;
            Color = snake;
            Control.BackColor = snake;
        }
        #endregion

        #region 方法
        public void DrawSnake(Blocks[,] data)//一开始绘制蛇
        {
            for (int i = 5; i < 9; i++)
            {
                data[6, i] = new Snake(data[6, i], Color);
                AddSnake(data[6, i] as Snake, data);
            }
        }

        public void AddSnake(Snake obj, Blocks[,] data)//添加蛇
        {
            data[obj.XRow, obj.YRow] = obj;
            Head1 = new Point(obj.XRow, obj.YRow);
            Body1.Add(obj);
        }

        public void RemoveTail(Blocks[,] data, Color bg)//移去尾巴
        {
            //末尾的方块改为Map方块
            data[Body[0].XRow, Body[0].YRow] = new Map(data[Body[0].XRow, Body[0].YRow], bg);
            Body.RemoveAt(0);
        }
        #endregion
    }
}
