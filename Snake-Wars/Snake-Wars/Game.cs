using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Game
    {
        #region 字段
        Snake snake;                //蛇
        Food food;                  //食物
        Maps map;                   //地图

        bool[,] map_Bool;           //蛇的身体的位置
        Circle[,] circles;          //以二维数组表示地图中的格子数，是绘制的依据
        int score = 0;              //获得的分数
        int xRows;                  //游戏区域的列数 
        int yRows;                  //游戏区域的行数
        int bWidth;                 //格子的宽度
        int bHeight;                //格子的高度
        Panel pa;                   //游戏界面
        

        Color fcolor;               //前景色
        Color bcolor;               //背景色
        Timer timer;                //定时器

       
        Random random;              //随机生成食物
        
        Circle circle;              //基本方块
        Direction dir;              //移动方向
        int speed;                  //速度
        #endregion

        #region 初始化
        public Game(Panel pa)               //初始化游戏界面
        {
            this.pa = pa;
        }

        public void InitGame(int speed)     //初始化数据
        {
            fcolor = Color.Red;                     //前景色置为红色
            bcolor = Color.White;                   //背景色置为白色
            dir = Direction.Right;                  //初始方向
            speed = 1000;                           //初始速度为1秒刷新一次

            bWidth = bHeight = 15;                  //所占方格大小
            xRows = this.pa.Width / bWidth;         //地图列数
            yRows = this.pa.Height / bHeight;       //地图行数

            map_Bool = new bool[xRows, yRows];
            circles = new Circle[xRows, yRows];     //初始化数组

            timer.Enabled = true;
            timer.Interval = speed;                 //初始化定时器

            map = new Maps(circle, bcolor);         //初始化背景
            map.DrawMap(xRows, yRows, circles, bWidth, bHeight, pa); //背景设置

            InitSnake();
            InitFood();
        }

        public void InitFood()              //随机生成食物
        {
            random = new Random(unchecked((int)DateTime.Now.Ticks));
            Circle t = circle;
            int x = random.Next(bWidth);
            int y = random.Next(bHeight);
            while (true)
            {
                if (map_Bool[x, y])
                {
                    x = random.Next(bWidth);
                    y = random.Next(bHeight);
                }
                else
                    break;
            }
            t.Position = new Point(x, y);
            food = new Food(t, fcolor);
            circles[x, y] = new Circle(x, y, fcolor);
        }

        #endregion

        #region 游戏功能
        void Move()     //移动
        {
            switch (dir)
            {
                case Direction.Up:
                    if (snake.Head.X > 0)               //蛇头不在最上边
                    {
                        Circle front = circles[snake.Head.X, snake.Head.Y - 1];
                        if (GetFood(front))             //判断是否是食物
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//添加蛇身
                            InitFood();                 //更新食物
                            score += 20;
                        }
                        else if (CheckSnake(front))     //判断是否撞到自己
                        {
                            Gameover();
                            MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                        }
                        else
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//增加蛇头                         
                            RemoveTail(snake);          //移去尾巴
                        }
                    }
                    else    //到达最上边，撞墙死
                    {
                        Gameover();
                        MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                    }
                    break;
                case Direction.Down:
                    if (snake.Head.X < xRows - 1)       //不在最下边
                    {
                        Circle front = circles[snake.Head.X, snake.Head.Y + 1];
                        if (GetFood(front))             //判断是否是食物
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//添加蛇身
                            InitFood();                 //更新食物
                            score += 20;
                        }
                        else if (CheckSnake(front))     //是否撞到自己的
                        {
                            Gameover();
                            MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                        }
                        else
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//增加蛇头                           
                            RemoveTail(snake);         //移去尾巴
                        }
                    }
                    else
                    {
                        Gameover();
                        MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                    }
                    break;
                case Direction.Left:
                    if (snake.Head.Y > 0)               //不在最左边
                    {
                        Circle front = circles[snake.Head.X - 1, snake.Head.Y];
                        if (GetFood(front))             //判断是否是食物
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//添加蛇身
                            InitFood();                 //更新食物
                            score += 20;
                        }
                        else if (CheckSnake(front))     //判断是否撞到自己
                        {
                            Gameover();
                            MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                        }
                        else
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor)); //增加蛇头                            
                            RemoveTail(snake);         //移去尾巴
                        }
                    }
                    else    //到达最左边、撞墙死
                    {
                        Gameover();
                        MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                    }
                    break;
                case Direction.Right:
                    if (snake.Head.Y < yRows - 1)       //不在最右边 
                    {
                        Circle front = circles[snake.Head.X + 1, snake.Head.Y];
                        if (GetFood(front))             //判断是否是食物
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor));//添加蛇身
                            InitFood();                 //更新食物
                            score += 20;
                        }
                        else if (CheckSnake(front))     //判断是否撞到自己
                        {
                            Gameover();
                            MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                        }
                        else
                        {
                            AddSnake(new Circle(food.XRow, food.YRow, fcolor)); //增加蛇头                       
                            RemoveTail(snake);         //移去尾巴
                        }
                    }
                    else    //到达最右边，撞墙死
                    {
                        Gameover();
                        MessageBox.Show("非常遗憾，闯关失败(请重新开始)");
                    }
                    break;
            }
        }

        public void Start(int speed)
        {
            InitGame(speed); //初始化数据
            
            
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Continue()
        {
            timer.Start();
        }

        public void Gameover()              //游戏结束
        {
            this.pa.Controls.Clear();
            //this.pa.BackgroundImage = Image.FromFile(@" D:\c#\贪吃蛇\LOGINBG.png");
            this.pa.BackgroundImageLayout = ImageLayout.Stretch;
            this.timer.Enabled = false;
        }
        #endregion


        #region 对蛇操作
        public void InitSnake()             //初始化蛇
        {
            snake = new Snake(4, circle, dir, speed);
            Circle t = circle;              //临时变量
            for (int i = 3; i < 7; i--)
            {
                circles[i, 3] = new Circle(i, 3, fcolor); //初始化数组中的蛇
                map_Bool[i, 3] = true;
            }
        }

        public void AddSnake(Circle obj)    //添加蛇身
        {
            map_Bool[obj.XRow, obj.YRow] = true;
            snake.AddSnake(obj, circles);
        }

        public void RemoveTail(Snake obj)   //移去尾巴
        {          
            map_Bool[snake.Body[0].XRow, snake.Body[0].YRow] = false;//从蛇的身体移除
            snake.RemoveTail(obj,circles);
        }

        public bool CheckSnake(Circle obj)  //判断是否撞到自己
        {
            if (map_Bool[obj.XRow, obj.YRow])
                return true;
            else
                return false;
        }

        public bool GetFood(Circle obj)     //判断前面的是否是食物
        {
            if (obj.Position == food.Position)
                return true;
            else
                return false;
        }
        #endregion


    }
}
