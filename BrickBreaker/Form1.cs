using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Automation;
namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        List<Rectangle> bricks = new List<Rectangle>();
        HashSet<Keys> pressedKeys;
        List<Rectangle> blocks = new List<Rectangle>();
        int brickWidth = 150;
        int brickHeight = 50;
        int rowCount = 3;
        int lives = 3;
        int baseXSpeed = 10;
        int baseYSpeed = 10;
        Graphics gfx;
        Bitmap bmp;
        Point speed = new Point(10, 10);
        Rectangle ball;
        Rectangle paddle;
        //Rectangle block;

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
            for(int j = 0; j < rowCount; j++)
            {
                for(int i = 0; i < pictureBox1.Right /brickWidth; i++)
                {
                    Rectangle box = new Rectangle(i*brickWidth, j*brickHeight, brickWidth, brickHeight);
                    bricks.Add(box);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            paddle = new Rectangle(360, 389, 120, 15);
            ball = new Rectangle(384, 318, 30, 30);
            //block = new Rectangle(7, 9, 180, 50);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pressedKeys = new HashSet<Keys>();

            createBricks();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{lives}";
            gfx.Clear(Color.BlanchedAlmond);
            //gfx.FillRectangle(Brushes.DarkGray, block.X - 3, block.Y - 3, block.Width+6, block.Height+6);
            //gfx.FillRectangle(Brushes.LightCyan, block);
            gfx.FillRectangle(Brushes.BurlyWood, paddle);
            gfx.FillEllipse(Brushes.RosyBrown, ball);
            int brocks = bricks.Count();

            for (int i = 0; i < brocks; i++)
            {
                if(i <= brocks/3)
                {
                    gfx.FillRectangle(Brushes.DarkSlateGray, bricks[i]);
                    gfx.DrawRectangle(Pens.Gray, bricks[i].X - 3, bricks[i].Y - 3, bricks[i].Width + 3, bricks[i].Height + 3);
                }
                else if(i <= brocks * (2 / 3))
                {
                    gfx.FillRectangle(Brushes.OrangeRed, bricks[i]);
                    gfx.DrawRectangle(Pens.Gray, bricks[i].X - 3, bricks[i].Y - 3, bricks[i].Width + 3, bricks[i].Height + 3);
                }
                else if(i > brocks* (2 / 3))
                {
                    gfx.FillRectangle(Brushes.BlueViolet, bricks[i]);
                    gfx.DrawRectangle(Pens.Gray, bricks[i].X - 3, bricks[i].Y - 3, bricks[i].Width + 3, bricks[i].Height + 3);
                }
            }

            ball.X += speed.X;//speed.X;
            ball.Y += speed.Y;//speed.Y;

            if (ball.Top <= 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            if(ball.Bottom >= bmp.Height)
            {
                lives--;
                speed.Y = -Math.Abs(speed.Y);
            }
            if (ball.Left <= 0)
            {
                speed.X = Math.Abs(speed.X);
            }
            else if (ball.Right >= bmp.Width)
            {
                speed.X = -Math.Abs(speed.X);
            }
            if (intersects(ball, paddle))
            {   
                if(ball.Bottom <= (paddle.Width / 4) + paddle.X)
                {
                    speed.X = -2*Math.Abs(baseXSpeed);
                }
                if (ball.Bottom >= (paddle.Width / 1.25) + paddle.X)
                {
                    speed.X = 2*Math.Abs(baseXSpeed);
                }
               
                speed.Y = -Math.Abs(speed.Y);
            }
            else if (intersects(ball,paddle) && ball.Bottom > paddle.X + (paddle.Width / 4) && ball.Bottom < paddle.X + (paddle.Width / 1.25))
            {
                speed.X = baseXSpeed * 1;
                speed.Y = baseYSpeed;
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
                if(paddle.Right <= bmp.Width)
                {
                    paddle.X += 15;
                }
                
            }
            //fix:
            // color issue
            // corner issue
            // 
            for (int i = 0; i < bricks.Count; i++)
            {
                bool hit = false;
                if (bricks[i].Bottom >= ball.Top && ball.Left >= bricks[i].Left && ball.Right <= bricks[i].Right) 
                {
                    gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                    hit = true;
                    speed.Y = Math.Abs(speed.Y);
                }
                if (bricks[i].Top >= ball.Top && ball.Left >= bricks[i].Left && ball.Right <= bricks[i].Right)
                {
                    gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                    hit = true;
                    speed.Y = -Math.Abs(speed.Y);
                }
                if(ball.IntersectsWith(bricks[i]) && ball.Left <= bricks[i].Right)
                {
                    gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                    hit = true;
                    speed.X = 2*Math.Abs(baseXSpeed);
                }
                if(ball.IntersectsWith(bricks[i]) && ball.Right >= bricks[i].Left)
                {
                    gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                    hit = true;
                    speed.X = -2 * Math.Abs(baseYSpeed);
                }
                if(hit)
                {
                    bricks.RemoveAt(i);
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