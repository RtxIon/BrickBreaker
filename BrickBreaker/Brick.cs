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
        
        public Rectangle bick;
        public Rectangle RSide
        {
            get
            {
                return new Rectangle(bick.X + bick.Width, bick.Y, 1, bick.Height);
            }
        }
        public Rectangle LSide
        {
            get
            {
                return new Rectangle(bick.X, bick.Y, 1, bick.Height);
            }
        }
        public Rectangle BSide
        {
            get
            {
                return new Rectangle(bick.X, bick.Y + bick.Height, bick.Width, 1);
            }
        }
        public Rectangle TSide
        {
            get
            {
                return new Rectangle(bick.X, bick.Y, bick.Width, 1);
            }
        }
            
        public Color color;
        public Brick (int x, int y, int width, int height)
        {
            bick = new Rectangle(x, y, width, height);
        }


        /*public void Draw (Graphics gfx)
        {
            gfx.FillRectangle(new SolidBrush(color), bick); //very good solution.
        }*/
    }
}
