
namespace ScruffyGame
{
    partial class ScruffySplash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScruffySplash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loading_info1 = new System.Windows.Forms.PictureBox();
            this.scrufflogo = new System.Windows.Forms.PictureBox();
            this.loadingfront = new System.Windows.Forms.PictureBox();
            this.splash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading_info1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrufflogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingfront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splash)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // loading_info1
            // 
            this.loading_info1.BackgroundImage = global::ScruffyGame.Properties.Resources.usw_mike1;
            this.loading_info1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loading_info1.Location = new System.Drawing.Point(84, 366);
            this.loading_info1.Name = "loading_info1";
            this.loading_info1.Size = new System.Drawing.Size(621, 38);
            this.loading_info1.TabIndex = 0;
            this.loading_info1.TabStop = false;
            // 
            // scrufflogo
            // 
            this.scrufflogo.Image = global::ScruffyGame.Properties.Resources.newlogo;
            this.scrufflogo.Location = new System.Drawing.Point(84, 87);
            this.scrufflogo.Name = "scrufflogo";
            this.scrufflogo.Size = new System.Drawing.Size(621, 162);
            this.scrufflogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scrufflogo.TabIndex = 5;
            this.scrufflogo.TabStop = false;
            // 
            // loadingfront
            // 
            this.loadingfront.Image = global::ScruffyGame.Properties.Resources.loading_front;
            this.loadingfront.Location = new System.Drawing.Point(140, 255);
            this.loadingfront.Name = "loadingfront";
            this.loadingfront.Size = new System.Drawing.Size(26, 63);
            this.loadingfront.TabIndex = 2;
            this.loadingfront.TabStop = false;
            // 
            // splash
            // 
            this.splash.BackColor = System.Drawing.Color.Transparent;
            this.splash.Image = global::ScruffyGame.Properties.Resources.splashscreen;
            this.splash.Location = new System.Drawing.Point(0, -1);
            this.splash.Name = "splash";
            this.splash.Size = new System.Drawing.Size(800, 452);
            this.splash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splash.TabIndex = 0;
            this.splash.TabStop = false;
            this.splash.Click += new System.EventHandler(this.splash_Click);
            this.splash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splash_MouseDown);
            this.splash.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splash_MouseMove);
            this.splash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splash_MouseUp);
            // 
            // ScruffySplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loading_info1);
            this.Controls.Add(this.scrufflogo);
            this.Controls.Add(this.loadingfront);
            this.Controls.Add(this.splash);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScruffySplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scruffy The Pursurer of Sausages";
            this.Load += new System.EventHandler(this.ScruffySplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loading_info1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrufflogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingfront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox splash;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox loadingfront;
        private System.Windows.Forms.PictureBox scrufflogo;
        private System.Windows.Forms.PictureBox loading_info1;
    }
}

