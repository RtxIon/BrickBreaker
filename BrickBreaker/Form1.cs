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

        Graphics gfx;
        Bitmap bmp;
        Point speed = new Point(15, 15);
        HashSet<Keys> pressedKeys;
        Rectangle ball;
        Rectangle paddle;

        public Form1()
        {
            InitializeComponent();
            paddle = new Rectangle(360, 389, 80, 15);
            ball = new Rectangle(384, 318, 30, 30);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pressedKeys = new HashSet<Keys>();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.BlanchedAlmond);

            gfx.FillRectangle(Brushes.BurlyWood, paddle);
            gfx.FillEllipse(Brushes.RosyBrown, ball);

            pictureBox1.Image = bmp;
        }

    }
}