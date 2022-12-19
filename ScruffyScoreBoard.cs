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

namespace ScruffyGame
{
    public partial class ScruffyScoreBoard : Form
    {
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

        public ScruffyScoreBoard()
        {
            InitializeComponent();

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

            levelclearedmenu.Controls.Add(nobtn);
            nobtn.BackColor = Color.Transparent;

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

        }

        private void nobtn_MouseHover(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.nobtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn_highlighted));
        }

        private void nobtn_MouseLeave(object sender, EventArgs e)
        {
            //Shows highlighted button when user hovers over button
            this.nobtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn));
        }

        private void nobtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ScruffyMainMenu MainMenu = new ScruffyMainMenu();
            MainMenu.ShowDialog();
        }
    }
}
