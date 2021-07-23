using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mobil
{
    public partial class Form1 : Form
    {
        int gamespeed = 0;
        int coin = 0;
        int speed = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        void Over()
        {
            int plus = 0;
            label4.Text = speed.ToString();
            label6.Text = coin.ToString();
            
            if (Car.Bounds.IntersectsWith(Musuh1.Bounds))
            {
                rematchshow();
            }
            if (Car.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                plus += 1;
                pictureBox5.Visible = false;
            }
            if (Car.Bounds.IntersectsWith(Musuh2.Bounds))
            {
                rematchshow();
            }
            if (Car.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                plus += 1;
                pictureBox6.Visible = false;
            }
            if (Car.Bounds.IntersectsWith(Musuh3.Bounds))
            {
                rematchshow();
            }
            if (Car.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                plus += 1;
                pictureBox7.Visible = false;
            }
            if (plus > 0)
            {
                coin += 1;
            }
            if (gamespeed == 0)
            {
                coin = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveLine(gamespeed);
            MusuhMove(gamespeed);
            CoinMove(gamespeed);
            Over();
            if(coin >= 500)
            {
                finish();
            }
        }

        void finish()
        {
            timer1.Enabled = false;
            GameOver.Visible = false;
            Car.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label7.Visible = true;
            pictureBox8.Visible = true;
            Musuh1.Visible = false;
            Musuh2.Visible = false;
            Musuh3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            MoveLine(0);
            MusuhMove(0);
        }

        void rematchshow()
        {
            timer1.Enabled = false;
            GameOver.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            Musuh1.Visible = false;
            Musuh2.Visible = false;
            Musuh3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            Car.Visible = false;
            MoveLine(0);
            MusuhMove(0);
        }

        void rematchhide()
        {
            timer1.Enabled = true;
            GameOver.Visible = false;
            label2.Visible = false;
            label1.Visible = false;
            pictureBox8.Visible = false;
            label7.Visible = false;
            MoveLine(0);
            MusuhMove(0);
        }

        void MoveLine(int speed)
        {
            if (pictureBox1.Top > 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }
            if (pictureBox2.Top > 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }
            if (pictureBox3.Top > 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }
            if (pictureBox4.Top > 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Car.Left += -8;
            }
            if (e.KeyCode == Keys.Right)
            {
                Car.Left += 8;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed <= 20)
                {
                    gamespeed++;
                    speed += 10;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)
                {
                    gamespeed--;
                    speed -= 10;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                gamespeed = 0;
            }

        }

        Random r = new Random();
        int x;
        void MusuhMove(int speed)
        {
            if (Musuh1.Top > 500)
            {
                x = r.Next(0, 200);
                Musuh1.Location = new Point(x, 0);
                pictureBox5.Location = new Point(x, 0);
            }
            else
            {
                Musuh1.Top += speed;
            }
            if (Musuh2.Top > 500)
            {
                x = r.Next(0, 400);
                Musuh2.Location = new Point(x, 0);
            }
            else
            {
                Musuh2.Top += speed;
            }
            if (Musuh3.Top > 500)
            {
                x = r.Next(200, 400);
                Musuh3.Location = new Point(x, 0);
            }
            else
            {
                Musuh3.Top += speed;
            }

        }

        Random c = new Random();
        int d;
        void CoinMove(int speed)
        {
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;

            if (Car.Bounds.IntersectsWith(pictureBox5.Bounds) && Car.Bounds.IntersectsWith(pictureBox6.Bounds) && Car.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                timer1.Enabled=false;                
            }
            else
            {
                if (pictureBox5.Top > 500)
                {
                    d = c.Next(0, 200);
                    pictureBox5.Location = new Point(d, 0);
                }
                else
                {
                    pictureBox5.Top += speed;
                }
                if (pictureBox6.Top > 500)
                {
                    d = c.Next(0, 400);
                    pictureBox6.Location = new Point(d, 0);
                }
                else
                {
                    pictureBox6.Top += speed;
                }
                if (pictureBox7.Top > 500)
                {
                    d = c.Next(200, 400);
                    pictureBox7.Location = new Point(d, 0);
                }
                else
                {
                    pictureBox7.Top += speed;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rematchhide();
        }
    }
}
