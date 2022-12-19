
namespace ScruffyGame
{
    partial class ScruffyDeath
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScruffyDeath));
            this.nobtn = new System.Windows.Forms.PictureBox();
            this.yesbtn = new System.Windows.Forms.PictureBox();
            this.restartmenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nobtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartmenu)).BeginInit();
            this.SuspendLayout();
            // 
            // nobtn
            // 
            this.nobtn.BackColor = System.Drawing.Color.Sienna;
            this.nobtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nobtn.BackgroundImage")));
            this.nobtn.Location = new System.Drawing.Point(209, 124);
            this.nobtn.Name = "nobtn";
            this.nobtn.Size = new System.Drawing.Size(69, 68);
            this.nobtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nobtn.TabIndex = 8;
            this.nobtn.TabStop = false;
            this.nobtn.Click += new System.EventHandler(this.nobtn_Click);
            this.nobtn.MouseLeave += new System.EventHandler(this.nobtn_MouseLeave);
            this.nobtn.MouseHover += new System.EventHandler(this.nobtn_MouseHover);
            // 
            // yesbtn
            // 
            this.yesbtn.BackColor = System.Drawing.Color.Sienna;
            this.yesbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yesbtn.BackgroundImage")));
            this.yesbtn.Location = new System.Drawing.Point(80, 124);
            this.yesbtn.Name = "yesbtn";
            this.yesbtn.Size = new System.Drawing.Size(69, 68);
            this.yesbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.yesbtn.TabIndex = 7;
            this.yesbtn.TabStop = false;
            this.yesbtn.Click += new System.EventHandler(this.yesbtn_Click);
            this.yesbtn.MouseLeave += new System.EventHandler(this.yesbtn_MouseLeave);
            this.yesbtn.MouseHover += new System.EventHandler(this.yesbtn_MouseHover);
            // 
            // restartmenu
            // 
            this.restartmenu.BackColor = System.Drawing.Color.Sienna;
            this.restartmenu.Image = global::ScruffyGame.Properties.Resources.youdied;
            this.restartmenu.Location = new System.Drawing.Point(0, -1);
            this.restartmenu.Name = "restartmenu";
            this.restartmenu.Size = new System.Drawing.Size(359, 204);
            this.restartmenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.restartmenu.TabIndex = 6;
            this.restartmenu.TabStop = false;
            // 
            // ScruffyDeath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 203);
            this.Controls.Add(this.nobtn);
            this.Controls.Add(this.yesbtn);
            this.Controls.Add(this.restartmenu);
            this.Name = "ScruffyDeath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScruffyDeath";
            ((System.ComponentModel.ISupportInitialize)(this.nobtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartmenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox nobtn;
        private System.Windows.Forms.PictureBox yesbtn;
        private System.Windows.Forms.PictureBox restartmenu;
    }
}