using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ScruffyGame
{
    public partial class ScruffySplash : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        private const int CS_DROPSHADOW = 0x00020000;

        public ScruffySplash()
        {
            InitializeComponent();

            //Following to add transparncy to the logo          
            splash.Controls.Add(scrufflogo);
            scrufflogo.BackColor = Color.Transparent;

            //Following to allows pictureboxes to be transparent
            splash.Controls.Add(loadingfront);
            loadingfront.BackColor = Color.Transparent;

            splash.Controls.Add(loading_info1);
            loading_info1.BackColor = Color.Transparent;

            //Following to allow labels to be transparent when on top of picturebox
            //lblloading.FlatStyle = FlatStyle.Standard;
            //lblloading.Parent = splash;
            //lblloading.BackColor = Color.Transparent;
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

        private void ScruffySplash_Load(object sender, EventArgs e)
        {

        }

        private void splash_MouseDown(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void splash_MouseMove(object sender, MouseEventArgs e)
        {
            //When user clicks and hold on the form, will allow to move the form around the screen
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void splash_MouseUp(object sender, MouseEventArgs e)
        {
            //When user releases mouse click the form is left in its position
            mouseDown = false;
        }

        private void splash_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Loading bar, checks if certai files exists, if .dat doesnt exist it will be created
            loadingfront.Width += 3;
            if (loadingfront.Width >= 501)
            {
                timer1.Stop();
                ScruffyMainMenu f2 = new ScruffyMainMenu();
                f2.Show();
                this.Hide();
            }
            if (loadingfront.Width >= 201)
            {              
                if (File.Exists(@"Media/chomp.wav") || File.Exists(@"Media/scruffymusic.wav") || File.Exists(@"Media/victory.wav") || File.Exists(@"Media/highscore.wav") || File.Exists(@"Media/middlescore.wav") || File.Exists(@"Media/lowscore.wav"))
                {
                    this.loading_info1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.usw_mike2));
                }
                else
                {
                    timer1.Stop();
                    if (MessageBox.Show("A file within the media folder is missing." + "\n" + "Click OK to quit", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Application.Exit();
                        foreach (var process in Process.GetProcessesByName("ScruffyGame.exe"))
                        {
                            process.Kill();
                        }
                    }
                }
            }
            if (loadingfront.Width >= 301)
            {
                if (File.Exists(@"ScruffyGame_ScoreBuildUp.dat"))
                {
                    this.loading_info1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.infoloading_1));
                }
                else
                {
                    timer1.Stop();
                    if (MessageBox.Show("ScruffyGame_ScoreBuildUp.dat is missing. A new file will be created." + "\n" + "Click OK to continue", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        FileStream fs = File.Create(@"ScruffyGame_ScoreBuildUp.dat");
                        timer1.Start();
                    }
                }
            }
            if (loadingfront.Width >= 401)
            {
                if (File.Exists(@"ScruffyGame_ScoreBoard.dat"))
                {
                    this.loading_info1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.infoloading_2));
                }
                else
                {
                    timer1.Stop();
                    if (MessageBox.Show("ScruffyGame_ScoreBoard.dat is missing. A new file will be created." + "\n" + "Click OK to continue", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        using (StreamWriter stream = new StreamWriter("ScruffyGame_ScoreBoard.dat", true))
                            stream.WriteLine("60,Scruffy" + "\n" + "58,Mike" + "\n" + "55,Alix" + "\n" + "44,David" + "\n" + "40,Terry" + "\n" + "35,Joanna" + "\n" + "30,Arron" + "\n" + "28,Ash" + "\n" + "20,Nathan" + "\n" + "10,Jazz");
                        timer1.Start();
                    }
                }
            }
        }
    }
}
