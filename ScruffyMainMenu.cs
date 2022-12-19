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
using System.Diagnostics;

namespace ScruffyGame
{
    public partial class ScruffyMainMenu : Form
    {
        //Allow user to move the form around the screen
        private bool mouseDown;
        private Point lastLocation;

        //Count for Switch Table Mute/Unute button to loop
        int count = 0;

        //Background music
        //SoundPlayer backgroundmusic = new SoundPlayer(Properties.Resources.scruffymusic);

        //Windows Shadow
        private const int CS_DROPSHADOW = 0x00020000;

        public ScruffyMainMenu()
        {
            InitializeComponent();

            //Following to allows pictureboxes to be transparent by adding pictureboxes to inherit from parent which is bg_scrolling
            bg_scrolling.Controls.Add(btn_play);
            bg_scrolling.Controls.Add(btn_highscore);
            bg_scrolling.Controls.Add(btn_exit);
            bg_scrolling.Controls.Add(scrufflogo);
            bg_scrolling.Controls.Add(btnsound);
            bg_scrolling.Controls.Add(btnminimize);
            btn_play.BackColor = Color.Transparent;
            btn_highscore.BackColor = Color.Transparent;
            btn_exit.BackColor = Color.Transparent;
            scrufflogo.BackColor = Color.Transparent;
            btnsound.BackColor = Color.Transparent;
            btnminimize.BackColor = Color.Transparent;

            //Further controls to enable transparency and remove white background when hovering/clicked buttons
            btn_play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btn_play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btn_highscore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btn_highscore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnsound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnsound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnminimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnminimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            scrufflogo.Invalidate();
            btn_play.Invalidate();
            btn_highscore.Invalidate();
            btn_exit.Invalidate();
            btnsound.Invalidate();
            btnminimize.Invalidate();

            //Background music will start playing when form loads
            //backgroundmusic.Play();
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

        private void ScruffyMainMenu_Load(object sender, EventArgs e)
        {
            axBackgroundMusic.URL = @"media/scruffymusic.wav";
            axBackgroundMusic.Ctlcontrols.play();
        }

        private void timer_scroll_Tick(object sender, EventArgs e)
        {
            {
                //Enable buttons/logo to remain "static" while background is moving due to being linked to timer
                bg_scrolling.Left -= 1;
                btn_play.Left += 1;
                btn_highscore.Left += 1;
                btn_exit.Left += 1;
                scrufflogo.Left += 1;
                btnsound.Left += 1;
                btnminimize.Left += 1;

                //Background scolling stops when x reaches -3350. Made it smoother by setting the form's DoubleBuffered option to True
                if (bg_scrolling.Left <= -3350)
                {
                    timer_scroll.Enabled = false;
                }
            }
        }

        private void bg_scrolling_MouseDown(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void bg_scrolling_MouseMove(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void bg_scrolling_MouseUp(object sender, MouseEventArgs e)
        {
            //When user releases mouse click the form is left in its position
            mouseDown = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_play_highlighted));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_play));
        }

        private void btn_highscore_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btn_highscore.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_higscores_highlighted));
        }

        private void btn_highscore_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btn_highscore.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_higscores));
        }

        private void btn_exit_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.btn_exit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_exit_highlighted));
        }

        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            //Reverts back to normal unhighlighted button when cursor moves away
            this.btn_exit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_exit));
        }

        private void scrufflogo_MouseDown(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void scrufflogo_MouseMove(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void scrufflogo_MouseUp(object sender, MouseEventArgs e)
        {
            //When user releases mouse click the form is left in its position
            mouseDown = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //When FormBorderStyle is set to none, there is no quit/minimize buttons, so add quit button
            //Application.Exit();

            if (MessageBox.Show("Are you sure you want to close this game?" + "\n" + "Click Yes to close.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                foreach (var process in Process.GetProcessesByName("ScruffyGame"))
                {
                    process.Kill();
                }
            }
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
            //A switch table to toggle between mute/unmute buttons an to enable/disable background music. Windows sound player is limited so there is no "mute" option
            Start:
                count++;
                switch (count)
                {
                    case 1:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btnsound_mute));
                    //backgroundmusic.Stop();
                    axBackgroundMusic.Ctlcontrols.pause();
                    break;
                    case 2:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btnsound));
                    //backgroundmusic.Play();
                    axBackgroundMusic.Ctlcontrols.play();
                        break;
                    default:
                    count = 0;
                        goto Start;
                }
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            //Added minimize button as setting FormBorderStyle to none removes it
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            //SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            //audio.Play();
            axBackgroundMusic.Ctlcontrols.stop();
            this.Hide();
            ScruffyMainGame MainGame = new ScruffyMainGame();
            MainGame.ShowDialog();
        }

        private void btn_highscore_Click(object sender, EventArgs e)
        {
            axBackgroundMusic.Ctlcontrols.stop();
            this.Hide();
            ScruffyScoreBoard ScruffyScoreBoard = new ScruffyScoreBoard();
            ScruffyScoreBoard.ShowDialog();

        }
    }
}
