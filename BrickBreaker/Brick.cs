using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    internal class Brick
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public bool draw; // if draw is false, whenever the timer ticks, don't draw the rectangle
        public Brick (int x, int y, int width, int height, bool draw)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.draw = draw;
        }

        public void disappear (Graphics gfx, Rectangle brock)
        {// if ball intersects with the brick, make the brick disappear.
            gfx.FillRectangle(Brushes.BlanchedAlmond, brock); // not a good solution.
        }
    }
}
