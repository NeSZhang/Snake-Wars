using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Wars
{
    class Food : Circle
    {
        public Food(Circle obj, Color food)
        {
            this.XRow = obj.XRow;//横向列
            this.YRow = obj.YRow;//纵向行
            this.Label = obj.Label;//标签
            this.Color = obj.Color;//颜色
            this.Position = obj.Position;//位置
        }

    }
}
