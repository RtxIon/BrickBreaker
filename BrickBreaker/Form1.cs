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
        int brickWidth = 75;
        int brickHeight = 50;
        int rowCount = 3;
        int lives = 3;
        int baseXSpeed = 10;
        int baseYSpeed = 10;
        bool draw = false;
        Graphics gfx;
        Bitmap bmp;
        PointF speed = new PointF(10.00f, 10.00f);
        RectangleF ball;
        Rectangle paddle;
        

        List<Brick> bicks = new List<Brick>();

        bool intersects(RectangleF a, Rectangle b)
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
            for (int j = 0; j < rowCount; j++)
            {
                for (int i = 0; i < pictureBox1.Right / brickWidth; i++)
                {
                    Rectangle box = new Rectangle(i * brickWidth, j * brickHeight, brickWidth, brickHeight);
                    Brick bick = new Brick(box.X, box.Y, box.Width, box.Height);
                    bricks.Add(box);
                    bicks.Add(bick);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            paddle = new Rectangle(360, 389, 120, 15);
            ball = new RectangleF(384f, 318f, 30f, 30f);
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
            gfx.FillRectangle(Brushes.BurlyWood, paddle);
            gfx.FillRectangle(Brushes.RosyBrown, ball);

            int brocks = bricks.Count();
            int bics = bicks.Count();
            while (lives > 0)
            { 
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (i <= brocks / 3)
                    {
                        gfx.FillRectangle(Brushes.DarkSlateGray, bricks[i]);
                        gfx.DrawRectangle(Pens.Gray, bricks[i].X - 3, bricks[i].Y - 3, bricks[i].Width + 3, bricks[i].Height + 3);
                    }
                    else if (i <= brocks * (2 / 3))
                    {
                        gfx.FillRectangle(Brushes.OrangeRed, bricks[i]);
                        gfx.DrawRectangle(Pens.Gray, bricks[i].X - 3, bricks[i].Y - 3, bricks[i].Width + 3, bricks[i].Height + 3);
                    }
                    else if (i > brocks * (2 / 3))
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
                if (ball.Bottom >= bmp.Height + 5)
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
                    float lhalf = paddle.Width / 2;

                    if (ball.X <= paddle.X + lhalf)// left half of paddle
                    {
                        float pos = lhalf - (ball.Width / 2);
                        speed.X *= pos / lhalf;
                    }
                    else if (ball.X >= paddle.X + paddle.Width)// right half of paddle
                    {
                        float pos = paddle.Width / 2;
                        speed.X *= pos / speed.X;
                    }
                    speed.Y = -Math.Abs(speed.Y);
                }

                if (pressedKeys.Contains(Keys.Left))
                {
                    if (paddle.Left >= 0)
                    {
                        paddle.X -= 15;
                    }
                }
                else if (pressedKeys.Contains(Keys.Right))
                {
                    if (paddle.Right <= bmp.Width)
                    {
                        paddle.X += 15;
                    }
                }

                for (int i = 0; i < bricks.Count(); i++)
                {
                    bool hit = false;

                    if (ball.IntersectsWith(bicks[i].BSide))
                    {
                        gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                        hit = true;
                        speed.Y = Math.Abs(speed.Y);
                    }
                    if (ball.IntersectsWith(bicks[i].TSide))
                    {
                        gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                        hit = true;
                        speed.Y = -Math.Abs(speed.Y);
                    }
                    if (ball.IntersectsWith(bicks[i].RSide))
                    {
                        gfx.FillRectangle(Brushes.Maroon, bricks[i]);
                        hit = true;
                        speed.X = 2 * Math.Abs(baseXSpeed);
                    }
                    if (ball.IntersectsWith(bicks[i].LSide))
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