
namespace ScruffyGame
{
    partial class ScruffyQuit
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
            this.quitmenu = new System.Windows.Forms.PictureBox();
            this.yesbtn = new System.Windows.Forms.PictureBox();
            this.nobtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.quitmenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nobtn)).BeginInit();
            this.SuspendLayout();
            // 
            // quitmenu
            // 
            this.quitmenu.Image = global::ScruffyGame.Properties.Resources.doyoureallywanttoquit;
            this.quitmenu.Location = new System.Drawing.Point(0, -2);
            this.quitmenu.Name = "quitmenu";
            this.quitmenu.Size = new System.Drawing.Size(359, 204);
            this.quitmenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.quitmenu.TabIndex = 0;
            this.quitmenu.TabStop = false;
            // 
            // yesbtn
            // 
            this.yesbtn.BackgroundImage = global::ScruffyGame.Properties.Resources.tick;
            this.yesbtn.Location = new System.Drawing.Point(80, 123);
            this.yesbtn.Name = "yesbtn";
            this.yesbtn.Size = new System.Drawing.Size(69, 68);
            this.yesbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.yesbtn.TabIndex = 1;
            this.yesbtn.TabStop = false;
            this.yesbtn.Click += new System.EventHandler(this.yesbtn_Click);
            this.yesbtn.MouseLeave += new System.EventHandler(this.yesbtn_MouseLeave);
            this.yesbtn.MouseHover += new System.EventHandler(this.yesbtn_MouseHover);
            // 
            // nobtn
            // 
            this.nobtn.BackgroundImage = global::ScruffyGame.Properties.Resources.closebtn;
            this.nobtn.Location = new System.Drawing.Point(209, 123);
            this.nobtn.Name = "nobtn";
            this.nobtn.Size = new System.Drawing.Size(69, 68);
            this.nobtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nobtn.TabIndex = 2;
            this.nobtn.TabStop = false;
            this.nobtn.Click += new System.EventHandler(this.nobtn_Click);
            this.nobtn.MouseLeave += new System.EventHandler(this.nobtn_MouseLeave);
            this.nobtn.MouseHover += new System.EventHandler(this.nobtn_MouseHover);
            // 
            // ScruffyQuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(359, 203);
            this.Controls.Add(this.nobtn);
            this.Controls.Add(this.yesbtn);
            this.Controls.Add(this.quitmenu);
            this.DoubleBuffered = true;
            this.Name = "ScruffyQuit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScruffyQuit";
            this.Load += new System.EventHandler(this.ScruffyQuit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quitmenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nobtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox quitmenu;
        private System.Windows.Forms.PictureBox yesbtn;
        private System.Windows.Forms.PictureBox nobtn;
    }
}