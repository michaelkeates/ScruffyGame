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
    public partial class ScruffyLevelCleared : Form
    {
        int sausages;
        int poo;
        int timeleft;
        int healthleft;
        int incrementscore = 0;
        int totalscore;

        int highscore;
        int middlescore;
        int lowscore;

        string playername;

        string str1;
        string str2;
        string str3;
        string str4;
        string str5;
        string str6;
        string str7;
        string str8;
        string str9;
        string str10;
        string str11;

        public ScruffyLevelCleared()
        {
            InitializeComponent();

            StreamReader sr1 = new StreamReader(@"ScruffyGame_ScoreBuildUp.dat");
            str11 = sr1.ReadLine();

            Int32.TryParse(str11.Split(',')[0], out sausages);
            Int32.TryParse(str11.Split(',')[1], out poo);
            Int32.TryParse(str11.Split(',')[2], out timeleft);
            Int32.TryParse(str11.Split(',')[3], out healthleft);

            totalscore = ((233 - timeleft) / (sausages - poo + 1) + (233 - healthleft)) / 4;

            StreamReader sr2 = new StreamReader(@"ScruffyGame_ScoreBoard.dat");
            str1 = sr2.ReadLine();
            str2 = sr2.ReadLine();
            str3 = sr2.ReadLine();
            str4 = sr2.ReadLine();
            str5 = sr2.ReadLine();
            str6 = sr2.ReadLine();
            str7 = sr2.ReadLine();
            str8 = sr2.ReadLine();
            str9 = sr2.ReadLine();
            str10 = sr2.ReadLine();

            //First place
            firstplacelbl.Text = "1st" + " " + (str1.Split(',')[1]) + " " + (str1.Split(',')[0]);

            //Second Place
            secondplacelbl.Text = "2nd" + " " + (str2.Split(',')[1]) + " " + (str2.Split(',')[0]);

            //Third Place
            thirdplacelbl.Text = "3rd" + " " + (str3.Split(',')[1]) + " " + (str3.Split(',')[0]);

            //Fourth Place
            fourthplacelbl.Text = "4th" + " " + (str4.Split(',')[1]) + " " + (str4.Split(',')[0]);

            //Fifth Place
            fithplacelbl.Text = "5th" + " " + (str5.Split(',')[1]) + " " + (str5.Split(',')[0]);

            //Sixth Place
            sixthplacelbl.Text = "6th" + " " + (str6.Split(',')[1]) + " " + (str6.Split(',')[0]);

            //Seventh Place
            seventhplacelbl.Text = "7th" + " " + (str7.Split(',')[1]) + " " + (str7.Split(',')[0]);

            //Eighth Place
            eighthplacelbl.Text = "8th" + " " + (str8.Split(',')[1]) + " " + (str8.Split(',')[0]);

            //Ninth Place
            ninthplacelbl.Text = "9th" + " " + (str9.Split(',')[1]) + " " + (str9.Split(',')[0]);

            //Tenth Place
            tenthplacelbl.Text = "10th" + " " + (str10.Split(',')[1]) + " " + (str10.Split(',')[0]);

            this.TransparencyKey = Color.Sienna;
            this.BackColor = Color.Sienna;
            this.FormBorderStyle = FormBorderStyle.None;

            levelclearedmenu.Controls.Add(star1);
            star1.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(star2);
            star2.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(star3);
            star3.BackColor = Color.Transparent;

            levelclearedmenu.Controls.Add(yesbtn);
            yesbtn.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(nobtn);
            nobtn.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(scorelbl);
            scorelbl.BackColor = Color.Transparent;

            levelclearedmenu.Controls.Add(firstplacelbl);
            firstplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(secondplacelbl);
            secondplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(thirdplacelbl);
            thirdplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(fourthplacelbl);
            fourthplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(fithplacelbl);
            fithplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(sixthplacelbl);
            sixthplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(seventhplacelbl);
            seventhplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(eighthplacelbl);
            eighthplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(ninthplacelbl);
            ninthplacelbl.BackColor = Color.Transparent;
            levelclearedmenu.Controls.Add(tenthplacelbl);
            tenthplacelbl.BackColor = Color.Transparent;

            levelclearedmenu.Controls.Add(confirmbtn);
            confirmbtn.BackColor = Color.Transparent;

            scorelbl.Text = ("" + incrementscore + "");

            axVictory.URL = @"media/victory.wav";
            axVictory.Ctlcontrols.play();
        }

        private void confirmbtn_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.confirmbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.confirm_highlighted));
        }

        private void confirmbtn_MouseLeave(object sender, EventArgs e)
        {
            this.confirmbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.confirm));
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            this.confirmbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.confirm_disabled));

            yournametextbox.ReadOnly = true;

            confirmbtn.Visible = false;

            firstplacelbl.Visible = true;
            secondplacelbl.Visible = true;
            thirdplacelbl.Visible = true;
            fourthplacelbl.Visible = true;
            fithplacelbl.Visible = true;
            sixthplacelbl.Visible = true;
            seventhplacelbl.Visible = true;
            eighthplacelbl.Visible = true;
            ninthplacelbl.Visible = true;
            tenthplacelbl.Visible = true;

            playername = yournametextbox.Text;

            //Retreives scores from ScruffyGame_ScoreBoard.Dat and populates the labels each score from the top 10 lines and splits
            //the date by ,

            using (StreamWriter stream = new StreamWriter("ScruffyGame_ScoreBoard.dat", true))
                stream.WriteLine("" + totalscore + "," + playername);

            string inFile2 = @"ScruffyGame_ScoreBoard.dat";

            var contents2 = File.ReadAllLines(inFile2).OrderBy(line2 => Int32.Parse(line2.Split(',')[0])).ToList();

            //sorts scores from highest to lowest
            contents2.Reverse();

            //writes the sorted scores back into the dat file
            File.WriteAllLines(inFile2, contents2);

            //fetches the top 10 scores into the form

            StreamReader sr2 = new StreamReader(@"ScruffyGame_ScoreBoard.dat");
            str1 = sr2.ReadLine();
            str2 = sr2.ReadLine();
            str3 = sr2.ReadLine();
            str4 = sr2.ReadLine();
            str5 = sr2.ReadLine();
            str6 = sr2.ReadLine();
            str7 = sr2.ReadLine();
            str8 = sr2.ReadLine();
            str9 = sr2.ReadLine();
            str10 = sr2.ReadLine();

            //First place
            firstplacelbl.Text = "1st" + " " + (str1.Split(',')[1]) + " " + (str1.Split(',')[0]);

            //Second Place
            secondplacelbl.Text = "2nd" + " " + (str2.Split(',')[1]) + " " + (str2.Split(',')[0]);

            //Third Place
            thirdplacelbl.Text = "3rd" + " " + (str3.Split(',')[1]) + " " + (str3.Split(',')[0]);

            //Fourth Place
            fourthplacelbl.Text = "4th" + " " + (str4.Split(',')[1]) + " " + (str4.Split(',')[0]);

            //Fifth Place
            fithplacelbl.Text = "5th" + " " + (str5.Split(',')[1]) + " " + (str5.Split(',')[0]);

            //Sixth Place
            sixthplacelbl.Text = "6th" + " " + (str6.Split(',')[1]) + " " + (str6.Split(',')[0]);

            //Seventh Place
            seventhplacelbl.Text = "7th" + " " + (str7.Split(',')[1]) + " " + (str7.Split(',')[0]);

            //Eighth Place
            eighthplacelbl.Text = "8th" + " " + (str8.Split(',')[1]) + " " + (str8.Split(',')[0]);

            //Ninth Place
            ninthplacelbl.Text = "9th" + " " + (str9.Split(',')[1]) + " " + (str9.Split(',')[0]);

            //Tenth Place
            tenthplacelbl.Text = "10th" + " " + (str10.Split(',')[1]) + " " + (str10.Split(',')[0]);

            //if it reaches to the end of the dat, streaming of the dat file ends and closes
            if (sr2 != null) sr2.Close();
        }

        private void levelclearedtimer_Tick(object sender, EventArgs e)
        {          
            //Different sound is played depending how high the score is, shows a star as well

            scorelbl.Text = Convert.ToString(incrementscore);
            Int32.TryParse(str6.Split(',')[0], out lowscore);
            Int32.TryParse(str4.Split(',')[0], out middlescore);
            Int32.TryParse(str3.Split(',')[0], out highscore);
            if (incrementscore == totalscore)
            {
                scorelbl.Text = Convert.ToString(totalscore);
            }
            else
            {
                incrementscore++;
                if (incrementscore < lowscore)
                {
                    axLowScore.URL = @"media/lowscore.wav";
                    axLowScore.Ctlcontrols.play();
                    star1.Visible = true;
                }
                if (incrementscore < middlescore)
                {
                    axMiddleScore.URL = @"media/middlescore.wav";
                    axMiddleScore.Ctlcontrols.play();
                    star2.Visible = true;
                }
                if (incrementscore >= highscore)
                {
                    axHighScore.URL = @"media/highscore.wav";
                    axHighScore.Ctlcontrols.play();
                    star3.Visible = true;
                }
            }
        }

        private void yesbtn_MouseHover(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tick_highlighted));
        }

        private void yesbtn_DragLeave(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tick));
        }

        private void yesbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ScruffyMainMenu ScruffyMainMenu = new ScruffyMainMenu();
            ScruffyMainMenu.ShowDialog();
        }

        private void nobtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this game?" + "\n" + "Click Yes to close.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                foreach (var process in Process.GetProcessesByName("ScruffyGame"))
                {
                    process.Kill();
                }
            }
        }

        private void nobtn_MouseHover(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn_highlighted));
        }

        private void nobtn_MouseLeave(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn));
        }
    }
}
