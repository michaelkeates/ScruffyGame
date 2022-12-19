using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScruffyGame
{
    public partial class ScruffyOutOfTime : Form
    {
        public ScruffyOutOfTime()
        {
            InitializeComponent();

            this.TransparencyKey = Color.Sienna;
            this.BackColor = Color.Sienna;
            this.FormBorderStyle = FormBorderStyle.None;

            restartmenu.Controls.Add(yesbtn);
            yesbtn.BackColor = Color.Transparent;
            restartmenu.Controls.Add(nobtn);
            nobtn.BackColor = Color.Transparent;
        }

        private void yesbtn_MouseHover(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tick_highlighted));
        }

        private void yesbtn_MouseLeave(object sender, EventArgs e)
        {
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tick));
        }

        private void yesbtn_Click(object sender, EventArgs e)
        {
            ScruffyMainGame ScruffyMainGame = new ScruffyMainGame();
            ScruffyMainGame.Hide();
            this.Hide();
            ScruffyMainGame.ShowDialog();
        }

        private void nobtn_MouseHover(object sender, EventArgs e)
        {
            this.nobtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn_highlighted));
        }

        private void nobtn_MouseLeave(object sender, EventArgs e)
        {
            this.nobtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closebtn));
        }

        private void nobtn_Click(object sender, EventArgs e)
        {
            ScruffyMainGame ScruffyMainGame = new ScruffyMainGame();
            ScruffyMainGame.Hide();
            this.Hide();
            ScruffyMainMenu ScruffyMainMenu = new ScruffyMainMenu();
            ScruffyMainMenu.ShowDialog();
        }
    }
}
