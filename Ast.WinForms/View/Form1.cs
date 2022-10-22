using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Timer = System.Windows.Forms.Timer;

namespace bead_aszt
{
    public partial class Aszteroid : Form
    {
        //int astSpeed = 0;
        int playerSpeed = 50;
        int Score;
        //int rocke;
        private Timer _timer = null!; // időzítő

        Random random = new Random();
        Random asterPos = new Random();

        bool goLeft, goRight;
        public Aszteroid()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(timer_Tick);
           // gameO.Hide();
            RestartGame();
            _timer.Start();
        }


        /*      private void Aszteroid_Load(object sender, EventArgs e)
              {

              }

              private void meteor1_Click(object sender, EventArgs e)
              {

              }*/

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

        private void timer_Tick(Object? sender, EventArgs e)
        {
            // moveAster(5);
            Score++;
            score.Text = "SCORE: " + Score;

            if (rocket.Left < 30)
            {
                goLeft = false;
            }
            else if (rocket.Left + rocket.Width > 600)
            {
                goRight = false;
            }

            if (goLeft)
            {
                rocket.Left -= playerSpeed;
            }

            if (goRight)
            {
                rocket.Left += playerSpeed;
            }
            if (rocket.Bounds.IntersectsWith(meteor1.Bounds))
                gameOver();
            if (rocket.Bounds.IntersectsWith(moon2.Bounds))
                gameOver();
            /* if ( rocket.Left < 1)
             {
                 goLeft = false;
             }
             else if ( rocket.Left +  rocket.Width > 600)
             {
                 goRight = false;
             }*/

            if (Score < 50)
            {
                moveAster(30);

            }

            else if (Score > 50 && Score < 100)
            {
                moveAster(20);
            }

            else if (Score > 100)
            {
                moveAster(30);
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && rocket.Left > 30)
            {
                rocket.Left -= playerSpeed;
            }
            if (goRight == true && rocket.Left < 600)
            {
                rocket.Left += playerSpeed;
            }
        }

        void moveAster(int speed)
        {
            if (meteor1.Top >= 480)
            {
                meteor1.Top = 0;
                int ap = asterPos.Next(1, 600);
                meteor1.Left = ap;
            }
            else { meteor1.Top += speed; }

            if (moon2.Top >= 480)
            {
                moon2.Top = 0;
                int ap = asterPos.Next(1, 600);
                moon2.Left = ap;
            }
            else { moon2.Top += speed; }



        }

        /*    private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void change (PictureBox moons1)
            {

            } */

        private void gameOver()
        {
            _timer.Stop();
            moveAster(0);
            btnStart.Enabled = true;
            gameO.Visible = true;
            gameO.Top = 260;
            gameO.Left = 150;
            boom.Visible = true;
            boom.Top = rocket.Top;
            boom.Left = rocket.Left;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RestartGame();
            gameO.Visible = false;
            /*   moveAster(10);
           // btnStart.Enabled = true;
            timer_Tick(sender, e);*/
        }


        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameO = new System.Windows.Forms.PictureBox();
            this.boom = new System.Windows.Forms.PictureBox();
            this.moon2 = new System.Windows.Forms.PictureBox();
            this.rocket = new System.Windows.Forms.PictureBox();
            this.meteor1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.score = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meteor1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.gameO);
            this.panel1.Controls.Add(this.boom);
            this.panel1.Controls.Add(this.moon2);
            this.panel1.Controls.Add(this.rocket);
            this.panel1.Controls.Add(this.meteor1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(680, 500);
            this.panel1.MinimumSize = new System.Drawing.Size(680, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 500);
            this.panel1.TabIndex = 0;
            // 
            // gameO
            // 
            this.gameO.Image = global::Ast.WinForms.Properties.Resources.gover1;
            this.gameO.Location = new System.Drawing.Point(284, 235);
            this.gameO.Name = "gameO";
            this.gameO.Size = new System.Drawing.Size(303, 120);
            this.gameO.TabIndex = 7;
            this.gameO.TabStop = false;
            this.gameO.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // boom
            // 
            this.boom.Image = global::Ast.WinForms.Properties.Resources.boom2;
            this.boom.Location = new System.Drawing.Point(126, 184);
            this.boom.Name = "boom";
            this.boom.Size = new System.Drawing.Size(50, 50);
            this.boom.TabIndex = 5;
            this.boom.TabStop = false;
            // 
            // moon2
            // 
            this.moon2.Image = global::Ast.WinForms.Properties.Resources.meteor1;
            this.moon2.Location = new System.Drawing.Point(427, 61);
            this.moon2.Name = "moon2";
            this.moon2.Size = new System.Drawing.Size(65, 90);
            this.moon2.TabIndex = 4;
            this.moon2.TabStop = false;
            // 
            // rocket
            // 
            this.rocket.Image = global::Ast.WinForms.Properties.Resources.moons_1;
            this.rocket.Location = new System.Drawing.Point(42, 36);
            this.rocket.Name = "rocket";
            this.rocket.Size = new System.Drawing.Size(153, 112);
            this.rocket.TabIndex = 3;
            this.rocket.TabStop = false;
            // 
            // meteor1
            // 
            this.meteor1.Image = global::Ast.WinForms.Properties.Resources.rocket_1;
            this.meteor1.Location = new System.Drawing.Point(320, 388);
            this.meteor1.Name = "meteor1";
            this.meteor1.Size = new System.Drawing.Size(60, 120);
            this.meteor1.TabIndex = 2;
            this.meteor1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStart.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(300, 509);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 32);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // score
            // 
            this.score.BackColor = System.Drawing.Color.Yellow;
            this.score.Location = new System.Drawing.Point(0, 498);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(680, 55);
            this.score.TabIndex = 1;
            this.score.Text = "SCORE:0";
            // 
            // Aszteroid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.score);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(700, 600);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "Aszteroid";
            this.Text = "Asteroid";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rocket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meteor1)).EndInit();
            this.ResumeLayout(false);

        }



        //restart == start
        private void RestartGame()
        {
            boom.Visible = false;
            btnStart.Enabled = false;
            goLeft = false;
            goRight = false;
            Score = 0;

            meteor1.Top = 0;
            int ap = asterPos.Next(300);
            meteor1.Left = ap;

            moon2.Top = 0;
            int ap1 = asterPos.Next(300, 500);
            moon2.Left = ap1;

            moveAster(10);

            _timer.Start();
            //gameTimeEvent();
        }

        private Panel panel1;
        private Button btnStart;
        private Label score;
        private PictureBox rocket;
        private PictureBox meteor1;
        private PictureBox moon2;
        private PictureBox gameO;

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private PictureBox boom;
        private EventHandler Form1_Load;
    }
}