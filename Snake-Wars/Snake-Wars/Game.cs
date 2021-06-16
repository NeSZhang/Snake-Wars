using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Wars
{
    class Game
    {
        #region 字段
        int XRows;                  //行数 
        int YRows;                  //列数
        int bWidth;                 //格子宽度
        int bHeight;                //格子高度

        Circle[,] data;             //存储格子
        Food food = new Food();     //食物
        Map map = new Map();        //地图
        Snake snake = new Snake();  //蛇
        Panel pa;                   //游戏界面
        Timer timer;                //定时器
        Directions dir;             //移动方向

        bool isHaveFood;            //判断是否有食物
        public int Score = 0;       //累计分数
        public bool isStoped = false;
        public bool isFinished = false;
        #endregion

        #region 初始化
        public Game(Panel pa)
        {
            this.pa = pa;
        }

        public void InitData(int speed)
        {
            bWidth = 15;                        //方块的宽度
            bHeight = 15;                       //方块的高度
            XRows = pa.Height / bHeight;        //地图的行数
            YRows = pa.Width / bWidth;          //地图的列数
            data = new Circle[XRows, YRows];    //方块的位置

            map.Color = Color.White;            //地图背景颜色
            snake.Color = Color.Red;            //蛇的颜色
            food.Color = Color.Black;           //食物的颜色
            snake.Body1 = new List<Snake>();    //实例化蛇的身体

            timer = new Timer();                //实例化timer 
            timer.Interval = speed;             //蛇的速度（间隔speed毫秒执行一次）
            timer.Enabled = true;               //计时器是否正在运行
            timer.Tick += new EventHandler(timer1_Tick);

            dir = Directions.Right;             //默认方向为右边
            isHaveFood = false;                 //默认没有食物
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Move();
            if (!isHaveFood)
            {
                food.DrawFood(data, XRows, YRows);
                isHaveFood = true;
            }
        }
        #endregion

        #region 支持函数
        void Move()
        {
            switch (dir)
            {
                case Directions.Up:
                    if (snake.Head1.X > 0)              //不在最上面
                    {
                        Circle front = data[snake.Head1.X - 1, snake.Head1.Y];
                        if (checkFood(front))           //是否是食物
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);   //添加蛇身
                            Score += 20;
                            isHaveFood = false;
                        }
                        else if (checkBody(front))     //是否撞到自己
                        {
                            Gameover(); isFinished = true;
                        }
                        else
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);   //添加蛇身                         
                            snake.RemoveTail(data, map.Color); //移去尾巴
                        }
                    }
                    else    //撞墙死
                    {
                        Gameover(); isFinished = true;
                    }
                    break;
                case Directions.Down:
                    if (snake.Head1.X < XRows - 1)
                    {
                        Circle front = data[snake.Head1.X + 1, snake.Head1.Y];
                        if (checkFood(front))           //是否是食物
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);
                            Score += 20;
                            isHaveFood = false;
                        }
                        else if (checkBody(front))     //是否撞到自己
                        {
                            Gameover(); isFinished = true;
                        }
                        else
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data); //增加蛇头                           
                            snake.RemoveTail(data, map.Color);     //移去尾巴
                        }
                    }
                    else
                    {
                        Gameover(); isFinished = true;
                    }
                    break;
                case Directions.Left:
                    if (snake.Head1.Y > 0)
                    {
                        Circle front = data[snake.Head1.X, snake.Head1.Y - 1];
                        if (checkFood(front))           //是否是食物
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);
                            Score += 20;
                            isHaveFood = false;
                        }
                        else if (checkBody(front))     //是否撞到自己
                        {
                            Gameover(); isFinished = true;
                        }
                        else
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);//增加蛇头                           
                            snake.RemoveTail(data, map.Color);//移去尾巴
                        }
                    }
                    else    //撞墙死
                    {
                        Gameover(); isFinished = true;
                    }
                    break;
                case Directions.Right:
                    if (snake.Head1.Y < YRows - 1)
                    {
                        Circle front = data[snake.Head1.X, snake.Head1.Y + 1];
                        if (checkFood(front))       //判断是否是食物
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);
                            Score += 20;
                            isHaveFood = false;
                        }
                        else if (checkBody(front))  //是否撞到自己
                        {
                            Gameover(); isFinished = true;
                        }
                        else
                        {
                            snake.AddSnake(new Snake(front, snake.Color), data);//增加蛇头 
                            snake.RemoveTail(data, map.Color);//移去尾巴
                        }
                    }
                    else        //撞墙死
                    {
                        Gameover(); isFinished = true;
                    }
                    break;
            }
        }
        public void ChangeDirections(Keys keys)//改变蛇的方向，不能向当前运动方向的反方向运动
        {
            if (keys == Keys.Up)
            {
                if (!(dir == Directions.Down))
                    dir = Directions.Up;
            }
            else if (keys == Keys.Down)
            {
                if (!(dir == Directions.Up))
                    dir = Directions.Down;
            }
            else if (keys == Keys.Left)
            {
                if (!(dir == Directions.Right))
                    dir = Directions.Left;
            }
            else if (keys == Keys.Right)
            {
                if (!(dir == Directions.Left))
                    dir = Directions.Right;
            }
        }
        bool checkFood(Circle obj)//判断是否是食物
        {
            if (obj is Food)
                return true;
            else
                return false;
        }
        bool checkBody(Circle obj)//判断是否是蛇
        {
            if (obj is Snake)
                return true;
            else
                return false;
        }
        #endregion

        #region 游戏功能
        public void Start(int speed)  //开始
        {
            InitData(speed);//初始化          
            map.DrawMap(XRows, YRows, data, bWidth, bHeight, pa);//设置背景
            snake.DrawSnake(data);
        }
        public void Stop()  //暂停
        {
            timer.Stop();
            isStoped = true;
        }
        public void Continue()  //继续
        {
            timer.Start();
            isStoped = false;
        }
        public void Gameover()  //游戏结束
        {     
            pa.Controls.Clear();
            
            timer.Enabled = false;
            MessageBox.Show("非常遗憾，闯关失败(请重新开始)！");
        }
        #endregion
    }
}