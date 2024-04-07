using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Automation;
namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        HashSet<Keys> pressedKeys;
        int brickWidth = 75;
        int brickHeight = 50;
        int rowCount = 3;
        int lives = 3;
        int baseXSpeed = 10;
        int baseYSpeed = 10;
        Graphics gfx;
        Bitmap bmp;
        PointF speed = new PointF(10.00f, 10.00f);
        RectangleF ball;
        Rectangle paddle;


        List<Brick> bricks = new List<Brick>();

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
                    if (j == 0)
                    {
                        Brick bick = new Brick(box.X, box.Y, box.Width, box.Height, Brushes.CadetBlue);
                        bricks.Add(bick);
                    }
                    if (j == 1)
                    {
                        Brick bick = new Brick(box.X, box.Y, box.Width, box.Height, Brushes.NavajoWhite);
                        bricks.Add(bick);
                    }
                    if (j == 2)
                    {
                        Brick bick = new Brick(box.X, box.Y, box.Width, box.Height, Brushes.Firebrick);
                        bricks.Add(bick);
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            losePanel.Visible = false;
            paddle = new Rectangle(360, 389, 120, 15);
            ball = new RectangleF(384f, 290f, 15, 15);
            //block = new Rectangle(7, 9, 180, 50);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pressedKeys = new HashSet<Keys>();

            createBricks();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(lives < 0)
            {
                timer1.Stop();
                losePanel.Visible = true;
            }
            label1.Text = $"{lives}";
            gfx.Clear(Color.BlanchedAlmond);
            gfx.FillRectangle(Brushes.BurlyWood, paddle);
            gfx.FillEllipse(Brushes.RosyBrown, ball);

            int brocks = bricks.Count;
            
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(gfx);
                gfx.DrawRectangle(Pens.Gray, bricks[i].Bick.X - 1, bricks[i].Bick.Y - 1, bricks[i].Bick.Width + 1, bricks[i].Bick.Height + 1);
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
                speed = new Point(0, 0);
                ball.X = 384;
                ball.Y = 290;
                restartTimer.Enabled = true;
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
                    paddle.X -= 17;
                }
            }
            else if (pressedKeys.Contains(Keys.Right))
            {
                if (paddle.Right <= bmp.Width)
                {
                    paddle.X += 17;
                }
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                bool hit = false;
                if (ball.IntersectsWith(bricks[i].BSide))
                {
                    bricks[i].BrushSolid = Brushes.Maroon;
                    bricks[i].Draw(gfx);
                    hit = true;
                    speed.Y = Math.Abs(speed.Y);
                }
                if (ball.IntersectsWith(bricks[i].TSide))
                {
                    bricks[i].BrushSolid = Brushes.Maroon;
                    bricks[i].Draw(gfx);
                    hit = true;
                    speed.Y = -Math.Abs(speed.Y);
                }
                if (ball.IntersectsWith(bricks[i].RSide))
                {
                    bricks[i].BrushSolid = Brushes.Maroon;
                    bricks[i].Draw(gfx);
                    hit = true;
                    speed.X = 2 * Math.Abs(baseXSpeed);
                }
                if (ball.IntersectsWith(bricks[i].LSide))
                {
                    bricks[i].BrushSolid = Brushes.Maroon;
                    bricks[i].Draw(gfx);
                    hit = true;
                    speed.X = -2 * Math.Abs(baseYSpeed);
                }
                if (hit)
                {
                    bricks.RemoveAt(i);
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

        private void restartTimer_Tick(object sender, EventArgs e)
        {
            restartTimer.Enabled = false;
            speed = new Point(7, 10);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            createBricks();
            losePanel.Hide();
            lives = 3;
            ball.X = 384;
            ball.Y = 290;
            speed = new Point(10, 10);
            paddle.X = 360;
            pressedKeys.Clear();
            timer1.Start();
            
        }
    }
}