using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace ScruffyGame
{
    public partial class ScruffyQuit : Form
    {
        public ScruffyQuit()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Sienna;
            this.BackColor = Color.Sienna;
            this.FormBorderStyle = FormBorderStyle.None;

            quitmenu.Controls.Add(yesbtn);
            yesbtn.BackColor = Color.Transparent;
            quitmenu.Controls.Add(nobtn);
            nobtn.BackColor = Color.Transparent;

            //Further controls to enable transparency and remove white background when hovering/clicked buttons
        }

        private void ScruffyQuit_Load(object sender, EventArgs e)
        {
            //quitmenu.Left = (this.ClientSize.Width - quitmenu.Width) / 2;
            //quitmenu.Top = (this.ClientSize.Height - quitmenu.Height / 3);
            //quitmenu.BackColor = Color.Transparent;
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
            Application.Exit();
            foreach (var process in Process.GetProcessesByName("ScruffyGame.exe"))
            {
                process.Kill();
            }
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
            this.Hide();
        }
    }
}
