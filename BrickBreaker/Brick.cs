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
        //public bool draw; // if draw is false, whenever the timer ticks, don't draw the rectangle
        public Rectangle bick;
        public Color color;
        public Brick (int x, int y, int width, int height,/* bool draw,*/ Color color)
        {
            bick = new Rectangle(x, y, width, height);
            //this.draw = draw;
            this.color = color;
        }

        public void Draw (Graphics gfx)
        {
            gfx.FillRectangle(new SolidBrush(color), bick); //very good solution.
        }
    }
}
