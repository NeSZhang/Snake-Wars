using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Snake
    {
        #region 字段
        List<Circle> body;              //蛇的身体
        private Point head;             //蛇头位置
        private int speed;              //速度
        private Direction direction;    //方向
        private bool alive;             //是否活着
        #endregion

        #region 属性
        public int Speed { get => speed; set => speed = value % 5; }
        public Point Head { get => head; set => head = value; }
        public Direction Direction { get => direction; set => direction = value; }
        public bool Alive { get => alive; set => alive = value; }
        internal List<Circle> Body { get => body; set => body = value; }
        #endregion

        #region 方法
        public Snake(int nums, Circle obj, Direction dir, int speed)    //初始化
        {
            alive = true;           //一开始活着
            this.speed = speed;     //初始化速度
            direction = dir;        //初始化方向
            head.X = obj.XRow;      //初始化蛇头的位置
            head.Y = obj.YRow;
            Body = new List<Circle>(nums);
            Circle t = obj;
            for (int i = nums; i > 0; i--)
            {
                switch(direction)
                {
                    case Direction.Up:
                        t.YRow += 15;
                        break;
                    case Direction.Down:
                        t.YRow -= 15;
                        break;
                    case Direction.Left:
                        t.XRow += 15;
                        break;
                    case Direction.Right:
                        t.XRow -= 15;
                        break;
                }
                Body.Add(t);
            }
        }

        public void AddSnake(Circle obj, Circle[,] circles)    //添加蛇身
        {
            Head = new Point(obj.XRow, obj.YRow);
            circles[obj.XRow, obj.YRow] = obj;
            Body.Add(obj);
        }

        public void RemoveTail(Snake obj, Circle[,] circles)   //移去尾巴
        {
            circles[Body[0].XRow, Body[0].YRow] = new Circle(Body[0].XRow, Body[0].YRow, Body[0].Color);
            Body.RemoveAt(0);
        }

        #endregion

    }
}
