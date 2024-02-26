using System.Windows.Forms;

namespace BrickBreaker
{

    public partial class Form1 : Form
    {
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

        void drawBricks(Form form, Brick template, int track, int numOfBricks)
        {// trying recursion. This funtion is meant to recursively create bricks that fill up the upper & middle portion of the screen.
            for(int count = track; count < numOfBricks; count++)
            {
                Rectangle newbrick = new Rectangle(template.x,template.y,template.width,template.height);
                if()
            }
            Rectangle
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
                paddle.X -= 15;
            }
            else if(pressedKeys.Contains(Keys.Right))
            {
                paddle.X += 15;
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