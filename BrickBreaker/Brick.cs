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

        


        public Rectangle Bick;
        public Brush BrushSolid;
        public Rectangle RSide
        {
            get
            {
                return new Rectangle(Bick.X + Bick.Width, Bick.Y, 1, Bick.Height);
            }
        }
        public Rectangle LSide
        {
            get
            {
                return new Rectangle(Bick.X, Bick.Y, 1, Bick.Height);
            }
        }
        public Rectangle BSide
        {
            get
            {
                return new Rectangle(Bick.X, Bick.Y + Bick.Height, Bick.Width, 1);
            }
        }
        public Rectangle TSide
        {
            get
            {
                return new Rectangle(Bick.X, Bick.Y, Bick.Width, 1);
            }
        }
            
        public Brick (int x, int y, int width, int height, Brush color)
        {
            Bick = new Rectangle(x, y, width, height);
            BrushSolid = color;
        }

        public void Draw (Graphics gfx)
        {
            gfx.FillRectangle(BrushSolid, Bick); //very good solution.
        }
    }
}
