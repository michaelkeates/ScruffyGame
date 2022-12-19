//1.  To get “Scruff” from point A to point B within the time limit otherwise the player loses the game.
//2.	The player will lose the game if “Scruff” loses all its health.
//3.	Scruff can lose health by going into fire, water, asteroid, eagle lander
//4.	The more sausages that “Scruff” eats (collects) the more points the player will have.
//5.	Each sausage will give “Scruff” some more health.
//6.	Each sausage is worth 2 points towards the final score.
//7.	Each sausage also will make “Scruff” ‘heavier’ which in turn will make “Scruff” slower in manoeuvrability.
//8.	“Scruff” will randomly ‘poo’ which will make her ‘lighter’ and will move faster again.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //Allow sounds and music to play
using System.Drawing.Drawing2D;
using System.Diagnostics; //Quit game by process
using System.Timers;
using System.IO;
using System.Runtime.InteropServices;

namespace ScruffyGame
{
    public partial class ScruffyMainGame : Form
    {
        //Declaring integers, booleans and static randomizer

        bool goLeft = false;
        bool goRight = false;
        bool jumping = false;

        int jumpSpeed = 10;
        int poojumpSpeed = 10;
        int score = 0;
        int poo = 0;
        int pooPercentage = rnd.Next(0, 100);
        int timefull = 233;
        int timeremaining;
        int healthlost = 0;

        int force = 0;

        int jumpTimeCoolDown = 0;

        int scruffySpeed = 8;
        int pooSpeed = 8;
        int backgroundSpeed = 8;
        //int scruffyhealth = 100;

        static Random rnd = new Random();


        /* ================= LUNARLANDER ================== */
        private double LunarLander_speedY = 0.0, LunarLander_speedX = 0.0;

        //original
        //private double LunarLander_posY = 50, LunarLander_posX = 200;

        private double LunarLander_posY = 75, LunarLander_posX = 2870;
        /* ==================== END ======================= */

        // Asteroid position
        private int x = 3870, y = 40;
        // Asteroid speed
        private int speedX = 2, speedY = 2;

        // Asteroid Cooldown
        int asteroidCoolDown = 0;

        //Windows Shadow
        private const int CS_DROPSHADOW = 0x00020000;

        //Count for Switch Table Mute/Unute button to loop
        int count = 0;

        public ScruffyMainGame()
        {
            InitializeComponent();
            TransparencyControls();
            setAsteroidRandomStartPos();

            axBackgroundMusic.URL = @"media/scruffymusic.wav";
            axBackgroundMusic.Ctlcontrols.play();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void ScruffyMainGame_Load(object sender, EventArgs e)
        {
            //Clear text file
            File.WriteAllText("ScruffyGame_ScoreBuildUp.dat", string.Empty);

            TimeLeft.Enabled = true;
            //TimeLeft.Start();

            sausagescorelbl.Text = "" + score + "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //foreach (var process in Process.GetProcessesByName("ScruffyGame.exe"))
            //{
            //    process.Kill();
            //}

            if (MessageBox.Show("Are you sure you want to close this game?" + "\n" + "Click Yes to close.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                foreach (var process in Process.GetProcessesByName("ScruffyGame"))
                {
                    process.Kill();
                }
            }
        }

        private void btnclose_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn_highlighted));
        }

        private void btnclose_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn));
        }

        private void btnminimize_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimizebtn_highlighted));
        }

        private void btnminimize_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimizebtn));
        }

        private void btnsound_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.soundbutton_highlighted));
        }

        private void btnsound_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btnsound));
        }

        private void btnsound_Click(object sender, EventArgs e)
        {
            {
            //A switch table to toggle between mute/unmute buttons an to pause/mute background music.
            Start:
                count++;
                switch (count)
                {
                    case 1:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btnsound_mute));
                        axBackgroundMusic.Ctlcontrols.pause();
                        break;
                    case 2:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btnsound));
                        axBackgroundMusic.Ctlcontrols.play();
                        break;
                    default:
                        count = 0;
                        goto Start;
                }
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            //Added minimize button as setting FormBorderStyle to none removes it
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            PooControl();

            scruff.Top += jumpSpeed;
            scruff_reverse.Top += jumpSpeed;
            scruff_tombstone.Top += jumpSpeed;
            //scruff_poo.Top += poojumpSpeed;

            // refresh scruff picture box consistently
            //scruff.Refresh();
            //scruff.Invalidate();

            if (goLeft == true && scruff.Left > 60)
            {
                scruff.Left -= scruffySpeed;
                scruff_reverse.Left -= scruffySpeed;
                scruff_tombstone.Left -= scruffySpeed;             
                poobar_bg.Left -= backgroundSpeed;
                lifebar_bg.Left -= backgroundSpeed;
                timer_bg.Left -= backgroundSpeed;
                sausagescore_bg.Left -= backgroundSpeed;

                btnclose.Left -= backgroundSpeed;
                btnminimize.Left -= backgroundSpeed;
                btnsound.Left -= backgroundSpeed;
            }

            if (goRight == true && scruff.Left > 60)
                //+ (scruff.Width + 60) < this.ClientSize.Width)
            {
                scruff.Left += scruffySpeed;
                scruff_reverse.Left += scruffySpeed;
                scruff_tombstone.Left += scruffySpeed;             
                poobar_bg.Left += backgroundSpeed;
                lifebar_bg.Left += backgroundSpeed;
                timer_bg.Left += backgroundSpeed;
                sausagescore_bg.Left += backgroundSpeed;

                btnclose.Left += backgroundSpeed;
                btnminimize.Left += backgroundSpeed;
                btnsound.Left += backgroundSpeed;
            }

            if (goLeft == true && poobar_bg.Left < 12)
            {
                poobar_bg.Left = 12;
                lifebar_bg.Left = 12;
                timer_bg.Left = 12;
                sausagescore_bg.Left = 12;

                scruff.Left += scruffySpeed;
                scruff_reverse.Left += scruffySpeed;
                scruff_tombstone.Left += scruffySpeed;
            }

            if (goLeft == true && btnclose.Left <= 585)
            {
                btnclose.Left = 573;
                btnminimize.Left = 519;
                btnsound.Left = 465;
            }

            if (jumping == true) // && jumpTimeCoolDown == 0)
            {
                jumpSpeed = -12;
                force -= 1;

                if (scruff_poo1.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo1.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo2.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo2.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo3.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo3.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo4.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo4.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo5.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo5.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo6.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo6.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo7.Visible == false)
                {
                    poojumpSpeed = -12;

                    if (scruff_poo7.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo8.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo8.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo9.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo9.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo10.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo10.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo11.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo11.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo12.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo12.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo13.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo13.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo14.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo14.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
                if (scruff_poo15.Visible == false)
                {
                    poojumpSpeed = -12;
                    if (scruff_poo15.Visible == true)
                    {
                        poojumpSpeed = 0;
                    }
                }
            }

            else if (jumping == false)
            {
                jumpSpeed = 12;
                poojumpSpeed = 12;

                foreach (Control x in bg_scrolling.Controls)
                {
                    //is X is a picture box and it has a tag of platform
                    if (x is PictureBox && (string)x.Tag == "Tile" || x is PictureBox && (string)x.Tag == "Crate2")
                    {
                        // then we are checking if scruff/player is colliding with the platform
                        if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)) || scruff_tombstone.Bounds.IntersectsWith(x.Bounds))
                        {
                            jumping = false;
                            jumpSpeed = 0;
                            force = 0;

                            if (scruff_poo1.Bounds.IntersectsWith(x.Bounds) || scruff_poo2.Bounds.IntersectsWith(x.Bounds) || scruff_poo3.Bounds.IntersectsWith(x.Bounds) || scruff_poo4.Bounds.IntersectsWith(x.Bounds) || scruff_poo5.Bounds.IntersectsWith(x.Bounds) || scruff_poo6.Bounds.IntersectsWith(x.Bounds) || scruff_poo7.Bounds.IntersectsWith(x.Bounds) || scruff_poo8.Bounds.IntersectsWith(x.Bounds) || scruff_poo9.Bounds.IntersectsWith(x.Bounds) || scruff_poo10.Bounds.IntersectsWith(x.Bounds) || scruff_poo11.Bounds.IntersectsWith(x.Bounds) || scruff_poo12.Bounds.IntersectsWith(x.Bounds) || scruff_poo13.Bounds.IntersectsWith(x.Bounds) || scruff_poo14.Bounds.IntersectsWith(x.Bounds) || scruff_poo15.Bounds.IntersectsWith(x.Bounds))
                            {
                                poojumpSpeed = 0;
                            }
                            //scruff.Top = (x.Top + 5);
                        }
                    }
                }
            }

            if (goLeft == true && bg_scrolling.Left < 0)
            {
                bg_scrolling.Left += backgroundSpeed;
                MoveGameElements("forward");
            }

            if (goRight == true && bg_scrolling.Left > -3367)
            {
                bg_scrolling.Left -= backgroundSpeed;
                MoveGameElements("back");
            }

            foreach (Control x in bg_scrolling.Controls)
            {
                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Fire")
                {
                    // then we are checking if the lunarlander is colliding with the platform
                    if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)))
                    {
                        lifebar_front.Width -= 1;
                        healthlost = healthlost += 1;
                    }
                }

                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Asteroid" || x is PictureBox && (string)x.Tag == "Water" || x is PictureBox && (string)x.Tag == "theEagle")
                {
                    // then we are checking if the lunarlander is colliding with the platform
                    if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)))
                    {
                        lifebar_front.Width -= 20;
                        healthlost = healthlost += 20;
                    }
                }

                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Crate")
                {
                    // then we are checking if scruff/player is colliding with the platform
                    if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)))
                    {
                        goRight = false;
                        jumping = false;
                        jumpSpeed = 0;
                        force = 0;

                        scruff.Left -= scruffySpeed;
                        scruff_reverse.Left -= scruffySpeed;
                        scruff_tombstone.Left -= scruffySpeed;
                        poobar_bg.Left -= backgroundSpeed;
                        lifebar_bg.Left -= backgroundSpeed;
                        timer_bg.Left -= backgroundSpeed;
                        sausagescore_bg.Left -= backgroundSpeed;

                        btnclose.Left -= backgroundSpeed;
                        btnminimize.Left -= backgroundSpeed;
                        btnsound.Left -= backgroundSpeed;
                        bg_scrolling.Left += backgroundSpeed;

                        //poobar_bg.Left -= 5;
                        //lifebar_bg.Left -= 5;
                        //timer_bg.Left -= 5;
                        //sausagescore_bg.Left -= 5;

                        //btnclose.Left -= 5;
                        //btnminimize.Left -= 5;
                        //btnsound.Left -= 5;

                        //scruff.Top = (x.Top + 5);
                    }
                }

                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Crate3")
                {
                    // then we are checking if scruff/player is colliding with the platform
                    if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds))) //&& (scruff_poo1.Bounds.IntersectsWith(x.Bounds)))
                    {
                        goLeft = false;
                        jumping = false;
                        jumpSpeed = 0;
                        poojumpSpeed = 0;
                        force = 0;

                        scruff.Left += scruffySpeed;
                        scruff_reverse.Left += scruffySpeed;
                        scruff_tombstone.Left += scruffySpeed;
                        poobar_bg.Left += backgroundSpeed;
                        lifebar_bg.Left += backgroundSpeed;
                        timer_bg.Left += backgroundSpeed;
                        sausagescore_bg.Left += backgroundSpeed;

                        btnclose.Left += backgroundSpeed;
                        btnminimize.Left += backgroundSpeed;
                        btnsound.Left += backgroundSpeed;
                        bg_scrolling.Left -= backgroundSpeed;
                    }
                }
            }

            if (lifebar_front.Width <= 68)
            {
                scruff.Hide();
                scruff_reverse.Hide();
                scruff_tombstone.Show();
                goLeft = false;
                goRight = false;
                jumping = false;
                TimeLeft.Enabled = false;
                GameTimer.Enabled = false;
                axBackgroundMusic.Ctlcontrols.stop();
                ScruffyDeath ScruffyDeath = new ScruffyDeath();
                ScruffyDeath.ShowDialog();
            }
            else
            {

            }

            foreach (Control x in bg_scrolling.Controls)
            {
                //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Sausage")
                {
                    // then we are checking if the lunarlander is colliding with the platform
                    if (scruff.Bounds.IntersectsWith(x.Bounds) && (scruff_reverse.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)) && (scruff_tombstone.Bounds.IntersectsWith(x.Bounds)) && x.Visible == true)
                    {
                        //chomp.Play();
                        axChomp.URL = @"media/chomp.wav";
                        axChomp.Ctlcontrols.play();
                        x.Visible = false;
                        poobar_front.Width += 20;
                        poo = poo + 1;
                        score = score + 1;
                        sausagescorelbl.Text = "" + score + "";
                        backgroundSpeed = backgroundSpeed -= 1;
                        scruffySpeed = scruffySpeed -= 1;
                        pooSpeed = pooSpeed -= 1;
                    }
                }
            }

            if (scruff.Left >= 3510)
            {

                using (StreamWriter stream = new StreamWriter("ScruffyGame_ScoreBuildUp.dat", true))
                    stream.WriteLine(score + "," + poo + "," + (timefull - timeremaining) + "," + healthlost);
                goLeft = false;
                goRight = false;
                jumping = false;
                GameTimer.Enabled = false;
                TimeLeft.Enabled = false;
                axBackgroundMusic.Ctlcontrols.stop();
                //axVictory.URL = @"media/victory.wav";
                //axVictory.Ctlcontrols.play();
                ScruffyLevelCleared ScruffyLevelCleared = new ScruffyLevelCleared();
                ScruffyLevelCleared.ShowDialog();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                scruff.Hide();
                scruff_reverse.Show();
                goLeft = true;
            }

            if (e.KeyCode == Keys.D)
            {
                scruff_reverse.Hide();
                scruff.Show();
                goRight = true;
            }

            if (e.KeyCode == Keys.W)
            {
                jumping = true;
                axBoing.URL = @"media/boing.wav";             
                axBoing.Ctlcontrols.play();
                JumpCoolDownTimer.Start();
            }
        }



        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.W)
            {
                jumping = false;
            }
        }

        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Tile" || x is PictureBox && (string)x.Tag == "BoundarySign" || x is PictureBox && (string)x.Tag == "Water" || x is PictureBox && (string)x.Tag == "Sign" || x is PictureBox && (string)x.Tag == "Crate" || x is PictureBox && (string)x.Tag == "Crate2" || x is PictureBox && (string)x.Tag == "Crate3" || x is PictureBox && (string)x.Tag == "Asteroid")
                {
                    if (direction == "back")
                    {
                        x.Left -= backgroundSpeed;
                        //poobar_bg.Left += backgroundSpeed;
                    }
                    if (direction == "forward")
                    {
                        x.Left += backgroundSpeed;
                        //poobar_bg.Left -= backgroundSpeed;
                    }
                }
            }
        }

        private void TimeLeftTick(object sender, EventArgs e)
        {
            timer_bar.Width -= 1;
            timeremaining = timer_bar.Width;

            if (timer_bar.Width == 68)
            {
                //TimeLeft.Stop();
                TimeLeft.Enabled = false;
                goLeft = false;
                goRight = false;
                jumping = false;
                axBackgroundMusic.Ctlcontrols.stop();

                if (TimeLeft.Enabled == false)
                {
                    ScruffyOutOfTime ScruffyOutOfTime = new ScruffyOutOfTime();
                    ScruffyOutOfTime.ShowDialog();
                }
            }
            else
            {

            }

            //TimeSpan tSecond = new TimeSpan(0, 0, 1);
            //countdowntime = countdowntime.Subtract(tSecond);
        }

        private void sign2_Click(object sender, EventArgs e)
        {

        }

        private void JumpCoolDown_Tick(object sender, EventArgs e)
        {
            jumpTimeCoolDown = jumpTimeCoolDown + 1;
            if (jumpTimeCoolDown == 12)
            {
                JumpCoolDownTimer.Stop();
                jumpTimeCoolDown = 0;
                jumping = false;
            }
        }

        private void PooControl()
        {
            if ((scruff_poo1.Visible == false) || (scruff_poo1.Visible == false) || (scruff_poo3.Visible == false) ||  (scruff_poo4.Visible == false) || (scruff_poo5.Visible == false) || (scruff_poo6.Visible == false) || (scruff_poo7.Visible == false) || (scruff_poo8.Visible == false) || (scruff_poo9.Visible == false) || (scruff_poo10.Visible == false) || (scruff_poo11.Visible == false) || (scruff_poo12.Visible == false) || (scruff_poo13.Visible == false) || (scruff_poo14.Visible == false) || (scruff_poo15.Visible == false))
            {
                scruff_poo1.Top += poojumpSpeed;
                scruff_poo2.Top += poojumpSpeed;
                scruff_poo3.Top += poojumpSpeed;

                scruff_poo4.Top += poojumpSpeed;
                scruff_poo5.Top += poojumpSpeed;
                scruff_poo6.Top += poojumpSpeed;

                scruff_poo7.Top += poojumpSpeed;
                scruff_poo8.Top += poojumpSpeed;
                scruff_poo9.Top += poojumpSpeed;

                scruff_poo10.Top += poojumpSpeed;
                scruff_poo11.Top += poojumpSpeed;
                scruff_poo12.Top += poojumpSpeed;

                scruff_poo13.Top += poojumpSpeed;
                scruff_poo14.Top += poojumpSpeed;
                scruff_poo15.Top += poojumpSpeed;

                if (goLeft == true && scruff_poo1.Visible == false)
                {
                    scruff_poo1.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo1.Visible == false)
                {
                    scruff_poo1.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo2.Visible == false)
                {
                    scruff_poo2.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo2.Visible == false)
                {
                    scruff_poo2.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo3.Visible == false)
                {
                    scruff_poo3.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo3.Visible == false)
                {
                    scruff_poo3.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo4.Visible == false)
                {
                    scruff_poo4.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo4.Visible == false)
                {
                    scruff_poo4.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo5.Visible == false)
                {
                    scruff_poo5.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo5.Visible == false)
                {
                    scruff_poo5.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo6.Visible == false)
                {
                    scruff_poo6.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo6.Visible == false)
                {
                    scruff_poo6.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo7.Visible == false)
                {
                    scruff_poo7.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo7.Visible == false)
                {
                    scruff_poo7.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo8.Visible == false)
                {
                    scruff_poo8.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo8.Visible == false)
                {
                    scruff_poo8.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo9.Visible == false)
                {
                    scruff_poo9.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo9.Visible == false)
                {
                    scruff_poo9.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo10.Visible == false)
                {
                    scruff_poo10.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo10.Visible == false)
                {
                    scruff_poo10.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo11.Visible == false)
                {
                    scruff_poo11.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo11.Visible == false)
                {
                    scruff_poo11.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo12.Visible == false)
                {
                    scruff_poo12.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo12.Visible == false)
                {
                    scruff_poo12.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo13.Visible == false)
                {
                    scruff_poo13.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo13.Visible == false)
                {
                    scruff_poo13.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo14.Visible == false)
                {
                    scruff_poo14.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo14.Visible == false)
                {
                    scruff_poo14.Left += pooSpeed;
                }
                if (goLeft == true && scruff_poo15.Visible == false)
                {
                    scruff_poo15.Left -= pooSpeed;
                }
                if (goRight == true && scruff_poo15.Visible == false)
                {
                    scruff_poo15.Left += pooSpeed;
                }
            }
            //axFart.Ctlcontrols.stop();
            if (poo > 1)
            {
                pooPercentage = rnd.Next(0, 100);

                //If pooPercentage is equal to 1 to 14. scruff_poo*.gif is enabled and a "fart" noise is played. Player speed is lowerd
                // which makes the player move faster or is "lighter"

                if (pooPercentage == 0 && scruff_poo1.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo1.Visible == false)
                    {
                        scruff_poo1.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo1.Visible = true))
                    {
                        scruff_poo1.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo1.Visible = true))
                    {
                        scruff_poo1.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 1 && scruff_poo2.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo2.Visible == false)
                    {
                        scruff_poo2.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo2.Visible = true))
                    {
                        scruff_poo2.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo2.Visible = true))
                    {
                        scruff_poo2.Left += pooSpeed;
                    }
                    //scruff_poo.Left = pooSpeed -= pooSpeed;
                    //scruff_poo.Left += scruffySpeed - scruffySpeed;
                }

                if (pooPercentage == 2 && scruff_poo3.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo3.Visible == false)
                    {
                        scruff_poo3.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo3.Visible = true))
                    {
                        scruff_poo3.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo3.Visible = true))
                    {
                        scruff_poo3.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 3 && scruff_poo4.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo4.Visible == false)
                    {
                        scruff_poo4.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo4.Visible = true))
                    {
                        scruff_poo4.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo4.Visible = true))
                    {
                        scruff_poo4.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 4 && scruff_poo5.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo5.Visible == false)
                    {
                        scruff_poo5.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo5.Visible = true))
                    {
                        scruff_poo5.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo5.Visible = true))
                    {
                        scruff_poo5.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 5 && scruff_poo6.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo6.Visible == false)
                    {
                        scruff_poo6.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo6.Visible = true))
                    {
                        scruff_poo6.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo6.Visible = true))
                    {
                        scruff_poo6.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 6 && scruff_poo7.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo7.Visible == false)
                    {
                        scruff_poo7.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo7.Visible = true))
                    {
                        scruff_poo7.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo7.Visible = true))
                    {
                        scruff_poo7.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 7 && scruff_poo8.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo8.Visible == false)
                    {
                        scruff_poo8.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo8.Visible = true))
                    {
                        scruff_poo8.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo8.Visible = true))
                    {
                        scruff_poo8.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 8 && scruff_poo9.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo9.Visible == false)
                    {
                        scruff_poo9.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo9.Visible = true))
                    {
                        scruff_poo8.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo9.Visible = true))
                    {
                        scruff_poo9.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 9 && scruff_poo10.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo10.Visible == false)
                    {
                        scruff_poo10.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo10.Visible = true))
                    {
                        scruff_poo10.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo10.Visible = true))
                    {
                        scruff_poo10.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 10 && scruff_poo11.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo11.Visible == false)
                    {
                        scruff_poo11.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo11.Visible = true))
                    {
                        scruff_poo11.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo11.Visible = true))
                    {
                        scruff_poo11.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 11 && scruff_poo12.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo12.Visible == false)
                    {
                        scruff_poo12.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo12.Visible = true))
                    {
                        scruff_poo12.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo12.Visible = true))
                    {
                        scruff_poo12.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 12 && scruff_poo13.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo13.Visible == false)
                    {
                        scruff_poo13.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo13.Visible = true))
                    {
                        scruff_poo13.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo13.Visible = true))
                    {
                        scruff_poo13.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 13 && scruff_poo14.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo14.Visible == false)
                    {
                        scruff_poo14.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo14.Visible = true))
                    {
                        scruff_poo14.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo14.Visible = true))
                    {
                        scruff_poo14.Left += pooSpeed;
                    }
                }

                if (pooPercentage == 14 && scruff_poo15.Visible == false)
                {
                    poo = poo - 1;
                    poobar_front.Width -= 20;
                    backgroundSpeed = backgroundSpeed += 1;
                    scruffySpeed = scruffySpeed += 1;
                    pooSpeed = pooSpeed += 1;
                    axFart.URL = @"media/fart.wav";
                    axFart.Ctlcontrols.play();

                    if (scruff_poo15.Visible == false)
                    {
                        scruff_poo15.Visible = true;
                    }
                    if ((goLeft == true) && (scruff_poo15.Visible = true))
                    {
                        scruff_poo15.Left -= pooSpeed;
                    }
                    if ((goRight == true) && (scruff_poo15.Visible = true))
                    {
                        scruff_poo15.Left += pooSpeed;
                    }
                }
            }
        }

        /* ================= LUNARLANDER ================== */
        // This timer is set up to run every 40 milliseconds (see timer1 Properties).
        // Every 40 milliseconds is 25 images per second - normal cinema frame rate.
        private void LunarLanderTimer_Tick(object sender, EventArgs e)
        {

            //for (int i = 0; i < myAsteroid.Length; ++i)
            //{
            //    myAsteroid[i].move();
            //}

            //for (int i = 0; i < myAsteroid.Length; ++i)
            //{
            //   if (myAsteroid[i].collidesWith(theEagle))
            //   {

            //       timer1.Enabled = false;     // Stop the timer
            //
            //       theEagle.Visible = false;
            //       theRocket.Visible = false;

            //       theExplosion.Visible = true;
            //       theExplosion.Location = new Point(theEagle.Left, theEagle.Top);
            //  }
            // }

            //Asteroidmove();


            // Simulate gravity: every time this Timer method is called speedY goes up by 0.1...
            //Changed to 0.001
            LunarLander_speedY = LunarLander_speedY + 0.001;
            // ... therefore the height of the lander changes faster and faster
            //     every time this timer function is running.
            LunarLander_posY = LunarLander_posY + LunarLander_speedY;


            // If the side rockets were fired (see Form1.keyDown event handler below)
            // then there is a speed in horizontal position. Adjust position accordingly.
            LunarLander_posX = LunarLander_posX + LunarLander_speedX;


            // Draw the LANDER.
            // 'Invalidate' prevents flicker. (Comment the line out to see the effect)
            theEagle.Invalidate();
            theEagle.Top = (int)LunarLander_posY;
            theEagle.Left = (int)LunarLander_posX;

            // If the ROCKET is visible (see Form1_KeyDown event handler below), draw it.
            theRocket.Invalidate(); // as above
            theRocket.Top = theEagle.Top + 129;
            theRocket.Left = theEagle.Left + 59;

            // Check if the LANDER has hit the ground
            // Original
            //if (theEagle.Top > 320)
            //{
            //   theEagle.Visible = false;
            //    theExplosion.Top = theEagle.Top;
            //    theExplosion.Left = theEagle.Left;
            //    theExplosion.Visible = true;
            //
            //    timer1.Enabled = false; x.Bounds
            //}

            // Check if the LANDER has hit the ground
            // Improved
            foreach (Control x in bg_scrolling.Controls)
            {
                 //is X is a picture box and it has a tag of platform
                if (x is PictureBox && (string)x.Tag == "Tile")
                {
                    // then we are checking if the lunarlander is colliding with the platform
                    if (theEagle.Bounds.IntersectsWith(x.Bounds))
                    {
                        LunarLander_speedY = 0.0; LunarLander_speedX = 0.0;
                        //LunarLanderTimer.Enabled = false;
                    }

                    // then we are checking if the lunarlander is colliding with the platform
                    if (asteroid.Bounds.IntersectsWith(x.Bounds) || asteroid.Bounds.IntersectsWith(theEagle.Bounds))
                    {
                        speedX = 0;
                        speedY = 0;
                        asteroid.Hide();
                        explosion.Show();

                        //Have disabled this sound effect as adding this in a control will lag the sound
                        //axExplosion.URL = @"media/Explosion+1.wav";
                        //axExplosion.Ctlcontrols.play();

                        //if (scruff.Left > 2600)
                        //{                         
                        //    axExplosion.Ctlcontrols.play();
                        //}

                        asteroidCoolDown = asteroidCoolDown + 1;

                        if (asteroidCoolDown == 20)
                        {
                            setAsteroidRandomStartPos();
                        }
                    }
                }
            }

            asteroid.Top += speedX;
            asteroid.Left += speedY;
            explosion.Top += speedX;
            explosion.Left += speedY;


        } // End of Lunar Lander timer method

        private void setAsteroidRandomStartPos()
        {
            asteroidCoolDown = 0;
            explosion.Hide();
            asteroid.Show();
            axExplosion.Ctlcontrols.stop();

            x = 2700;
            y = rnd.Next(0, 40);
            asteroid.Location = new Point(x, y);
            explosion.Location = new Point(x, y);

            speedX = rnd.Next(2, 8);
            speedY = rnd.Next(0, 6);
        }

        public void Asteroidmove()
        {
            x = x + speedX;
            y = y + speedY;

            //setAsteroidRandomStartPos();

            //if ((x > 645) || (y > 750))
            //{
            //    setAsteroidRandomStartPos();
           // }
            //ast.Invalidate();
            asteroid.Location = new Point(x, y);
            explosion.Location = new Point(x, y);
        }

        private void TransparencyControls()
        {
            bg_scrolling.Controls.Add(scruff);
            scruff.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(scruff_reverse);
            scruff_reverse.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(scruff_tombstone);
            scruff_tombstone.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(scruff_poo1);
            scruff_poo1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo2);
            scruff_poo2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo3);
            scruff_poo3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo4);
            scruff_poo4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo5);
            scruff_poo5.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo6);
            scruff_poo6.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo7);
            scruff_poo7.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo8);
            scruff_poo8.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo9);
            scruff_poo9.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo10);
            scruff_poo10.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo11);
            scruff_poo11.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo12);
            scruff_poo12.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo13);
            scruff_poo13.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo14);
            scruff_poo14.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(scruff_poo15);
            scruff_poo15.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(sausage1);
            sausage1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage2);
            sausage2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage3);
            sausage3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage4);
            sausage4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage5);
            sausage5.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage6);
            sausage6.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage7);
            sausage7.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage8);
            sausage8.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage9);
            sausage9.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage10);
            sausage10.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage11);
            sausage11.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage12);
            sausage12.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage13);
            sausage13.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage14);
            sausage14.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(sausage15);
            sausage15.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(sign2);
            sign2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(bush1);
            bush1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(matsign);
            matsign.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tree1);
            tree1.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(btnclose);
            btnclose.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(btnminimize);
            btnminimize.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(btnsound);
            btnsound.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(lifebar_bg);
            lifebar_bg.BackColor = Color.Transparent;
            lifebar_bg.Controls.Add(lifebar_front);
            lifebar_front.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(poobar_bg);
            poobar_bg.BackColor = Color.Transparent;
            poobar_bg.Controls.Add(poobar_front);
            poobar_front.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(timer_bg);
            timer_bg.BackColor = Color.Transparent;
            timer_bg.Controls.Add(timer_bar);
            timer_bar.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(sausagescore_bg);
            sausagescore_bg.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(tile1);
            tile1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile2);
            tile2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile3);
            tile3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile4);
            tile4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile5);
            tile5.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile6);
            tile6.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile7);
            tile7.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile8);
            tile8.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile9);
            tile9.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile10);
            tile10.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile11);
            tile11.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile12);
            tile12.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile13);
            tile13.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile14);
            tile14.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile15);
            tile15.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(tile16);
            tile16.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile17);
            tile17.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile18);
            tile18.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile19);
            tile19.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox2);
            pictureBox2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox3);
            pictureBox3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox4);
            pictureBox4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox5);
            pictureBox5.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(pictureBox6);
            pictureBox6.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox7);
            pictureBox7.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox8);
            pictureBox8.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox9);
            pictureBox9.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox10);
            pictureBox10.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(pictureBox11);
            pictureBox11.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox12);
            pictureBox12.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox13);
            pictureBox13.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox14);
            pictureBox14.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox15);
            pictureBox15.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(pictureBox16);
            pictureBox16.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox17);
            pictureBox17.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox18);
            pictureBox18.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox19);
            pictureBox19.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox20);
            pictureBox20.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(pictureBox21);
            pictureBox21.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox22);
            pictureBox22.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox23);
            pictureBox23.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox24);
            pictureBox24.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox25);
            pictureBox25.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(pictureBox28);
            pictureBox28.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox29);
            pictureBox29.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox30);
            pictureBox30.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox31);
            pictureBox31.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(pictureBox32);
            pictureBox32.BackColor = Color.Transparent;


            bg_scrolling.Controls.Add(tile20);
            tile20.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile21);
            tile21.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile22);
            tile22.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile23);
            tile23.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(matiasfire);
            matiasfire.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(matiasfire2);
            matiasfire2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(matiasfire3);
            matiasfire3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile24);
            tile24.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile25);
            tile25.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile26);
            tile26.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(lunarsign);
            lunarsign.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile27);
            tile27.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(tile28);
            tile28.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(finishsign);
            finishsign.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(water1);
            water1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(water2);
            water2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(water3);
            water3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(water4);
            water4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(water5);
            water5.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(crate1);
            crate1.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate2);
            crate2.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate3);
            crate3.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate4);
            crate4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate5);
            crate4.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate6);
            crate6.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate7);
            crate7.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate8);
            crate8.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate9);
            crate9.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate10);
            crate10.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate11);
            crate11.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate12);
            crate12.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate13);
            crate13.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate14);
            crate14.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate15);
            crate15.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(crate16);
            crate16.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate17);
            crate17.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate18);
            crate18.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate19);
            crate19.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate20);
            crate20.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate21);
            crate21.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate22);
            crate22.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate23);
            crate23.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate24);
            crate24.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate25);
            crate25.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate26);
            crate26.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(crate27);
            crate27.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(theEagle);
            theEagle.BackColor = Color.Transparent;
            bg_scrolling.Controls.Add(theRocket);
            theRocket.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(asteroid);
            asteroid.BackColor = Color.Transparent;

            bg_scrolling.Controls.Add(explosion);
            explosion.BackColor = Color.Transparent;

            //Further controls to enable transparency and remove white background when hovering/clicked buttons
            btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnminimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnminimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnsound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnsound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            sausagescore_bg.Controls.Add(sausagescorelbl);
            sausagescorelbl.BackColor = Color.Transparent;
        }

    }
}
