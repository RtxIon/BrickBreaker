using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace BrickBreaker
{

    public partial class Form1 : Form
    {
        List<List<Rectangle>> bricks = new List<List<Rectangle>>();

        bool intersects(Rectangle a, Rectangle b)
        {
            // a is ball |  b is paddle
            if (a.IntersectsWith(b))
            {
                gfx.FillRectangle(Brushes.Crimson, b);
                return true;
            }
            else
            {
                return false;
            }
        }



        void createBricks()
        {
            for(int j = 0; j < ((pictureBox1.Bottom) - pictureBox1.Bottom/2) - 1; j++)
            {
                List<Rectangle> row = new List<Rectangle>();
                for(int i = 0; i < pictureBox1.Right /50; i++)
                {
                    Rectangle box = new Rectangle(i, j * 50, 50, 50);
                    row.Add(box);
                }
                bricks.Add(row);
            }
        }

        Graphics gfx;
        Bitmap bmp;
        Point speed = new Point(15, 15);
        HashSet<Keys> pressedKeys;
        List<Rectangle> blocks = new List<Rectangle>();
        Rectangle ball;
        Rectangle paddle;
        Rectangle block;

        public Form1()
        {
            InitializeComponent();
            paddle = new Rectangle(360, 389, 80, 15);
            ball = new Rectangle(384, 318, 30, 30);
            block = new Rectangle(7, 9, 180, 50);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pressedKeys = new HashSet<Keys>();

            createBricks();
            for (int i = 0; i < bricks.Count; i++)
            {
                for (int j = 0; j < bricks[i].Count; j++)
                {
                    gfx.FillRectangle(Brushes.DarkSlateGray, bricks[i][j]);
                    gfx.FillRectangle(Brushes.DarkGray, bricks[i][j].X - 3, bricks[i][j].Y - 3, bricks[i][j].Width + 6, bricks[i][j].Height + 6);
                }

            }

           

            //Form.Sizechange // runs whenever the size of the form is changed.
            //https://planetcalc.com/8989/ <- This resource may help in sacaling things to the size of the form (screen).
            /*
             * scale factor for brick size can be this: 
             * 1. get ratio: currentScreenHeight/brickHeight & currentScreenWidth/brickWidth
             * 2. scale: newScreenHeight/brickHeight, newScreeWidth/brickWidth. currentBrickProportions*quotients
             * */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.BlanchedAlmond);
            gfx.FillRectangle(Brushes.DarkGray, block.X - 3, block.Y - 3, block.Width+6, block.Height+6);
            gfx.FillRectangle(Brushes.LightCyan, block);
            gfx.FillRectangle(Brushes.BurlyWood, paddle);
            gfx.FillEllipse(Brushes.RosyBrown, ball);

           
            ball.X += speed.X;//speed.X;
            ball.Y += speed.Y;//speed.Y;

            if (ball.Top <= 0 || ball.Bottom >= ClientSize.Height)
            {
                speed.Y *= -1;
            }
            if (ball.Left <= 0)
            {
                speed.X *= -1;
            }
            else if (ball.Right >= ClientSize.Width)
            {
                speed.X *= -1;
            }
            if (intersects(ball, paddle))
            { 
                speed.X = Math.Abs(speed.X);
                speed.Y *= -1;
            }

            if (pressedKeys.Contains(Keys.Left))
            {
                if(paddle.Left >= 0)
                {
                    paddle.X -= 15;
                }
            }
            else if(pressedKeys.Contains(Keys.Right))
            {
                if(paddle.Right <= pictureBox1.Right)
                {
                    paddle.X += 15;
                }
                
            }

            pictureBox1.Image = bmp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }
    }
}