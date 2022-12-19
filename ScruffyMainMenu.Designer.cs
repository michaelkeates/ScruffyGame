
namespace ScruffyGame
{
    partial class ScruffyMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScruffyMainMenu));
            this.timer_scroll = new System.Windows.Forms.Timer(this.components);
            this.btnminimize = new System.Windows.Forms.Button();
            this.btnsound = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_highscore = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.scrufflogo = new System.Windows.Forms.PictureBox();
            this.bg_scrolling = new System.Windows.Forms.PictureBox();
            this.axBackgroundMusic = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.scrufflogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg_scrolling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_scroll
            // 
            this.timer_scroll.Enabled = true;
            this.timer_scroll.Interval = 20;
            this.timer_scroll.Tick += new System.EventHandler(this.timer_scroll_Tick);
            // 
            // btnminimize
            // 
            this.btnminimize.BackgroundImage = global::ScruffyGame.Properties.Resources.minimizebtn;
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Location = new System.Drawing.Point(585, 12);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(48, 49);
            this.btnminimize.TabIndex = 9;
            this.btnminimize.UseVisualStyleBackColor = true;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            this.btnminimize.MouseLeave += new System.EventHandler(this.btnminimize_MouseLeave);
            this.btnminimize.MouseHover += new System.EventHandler(this.btnminimize_MouseHover);
            // 
            // btnsound
            // 
            this.btnsound.BackgroundImage = global::ScruffyGame.Properties.Resources.btnsound;
            this.btnsound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsound.FlatAppearance.BorderSize = 0;
            this.btnsound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsound.Location = new System.Drawing.Point(531, 12);
            this.btnsound.Name = "btnsound";
            this.btnsound.Size = new System.Drawing.Size(48, 49);
            this.btnsound.TabIndex = 8;
            this.btnsound.UseVisualStyleBackColor = true;
            this.btnsound.Click += new System.EventHandler(this.btnsound_Click);
            this.btnsound.MouseLeave += new System.EventHandler(this.btnsound_MouseLeave);
            this.btnsound.MouseHover += new System.EventHandler(this.btnsound_MouseHover);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::ScruffyGame.Properties.Resources.btn_exit;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_exit.Location = new System.Drawing.Point(223, 465);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(210, 69);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            this.btn_exit.MouseLeave += new System.EventHandler(this.btn_exit_MouseLeave);
            this.btn_exit.MouseHover += new System.EventHandler(this.btn_exit_MouseHover);
            // 
            // btn_highscore
            // 
            this.btn_highscore.BackColor = System.Drawing.Color.Transparent;
            this.btn_highscore.BackgroundImage = global::ScruffyGame.Properties.Resources.btn_higscores;
            this.btn_highscore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_highscore.FlatAppearance.BorderSize = 0;
            this.btn_highscore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_highscore.ForeColor = System.Drawing.Color.Transparent;
            this.btn_highscore.Location = new System.Drawing.Point(223, 390);
            this.btn_highscore.Name = "btn_highscore";
            this.btn_highscore.Size = new System.Drawing.Size(210, 69);
            this.btn_highscore.TabIndex = 6;
            this.btn_highscore.UseVisualStyleBackColor = false;
            this.btn_highscore.Click += new System.EventHandler(this.btn_highscore_Click);
            this.btn_highscore.MouseLeave += new System.EventHandler(this.btn_highscore_MouseLeave);
            this.btn_highscore.MouseHover += new System.EventHandler(this.btn_highscore_MouseHover);
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.Transparent;
            this.btn_play.BackgroundImage = global::ScruffyGame.Properties.Resources.btn_play;
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.ForeColor = System.Drawing.Color.Transparent;
            this.btn_play.Location = new System.Drawing.Point(223, 315);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(210, 69);
            this.btn_play.TabIndex = 5;
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            this.btn_play.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btn_play.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // scrufflogo
            // 
            this.scrufflogo.Image = global::ScruffyGame.Properties.Resources.newlogo;
            this.scrufflogo.Location = new System.Drawing.Point(12, 147);
            this.scrufflogo.Name = "scrufflogo";
            this.scrufflogo.Size = new System.Drawing.Size(621, 162);
            this.scrufflogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scrufflogo.TabIndex = 4;
            this.scrufflogo.TabStop = false;
            this.scrufflogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrufflogo_MouseDown);
            this.scrufflogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrufflogo_MouseMove);
            this.scrufflogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrufflogo_MouseUp);
            // 
            // bg_scrolling
            // 
            this.bg_scrolling.Image = global::ScruffyGame.Properties.Resources.BG_Wide;
            this.bg_scrolling.InitialImage = null;
            this.bg_scrolling.Location = new System.Drawing.Point(0, 0);
            this.bg_scrolling.Name = "bg_scrolling";
            this.bg_scrolling.Size = new System.Drawing.Size(4000, 750);
            this.bg_scrolling.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg_scrolling.TabIndex = 0;
            this.bg_scrolling.TabStop = false;
            this.bg_scrolling.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bg_scrolling_MouseDown);
            this.bg_scrolling.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bg_scrolling_MouseMove);
            this.bg_scrolling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bg_scrolling_MouseUp);
            // 
            // axBackgroundMusic
            // 
            this.axBackgroundMusic.Enabled = true;
            this.axBackgroundMusic.Location = new System.Drawing.Point(182, 600);
            this.axBackgroundMusic.Name = "axBackgroundMusic";
            this.axBackgroundMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBackgroundMusic.OcxState")));
            this.axBackgroundMusic.Size = new System.Drawing.Size(75, 23);
            this.axBackgroundMusic.TabIndex = 10;
            this.axBackgroundMusic.Visible = false;
            // 
            // ScruffyMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(645, 750);
            this.Controls.Add(this.axBackgroundMusic);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.btnsound);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_highscore);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.scrufflogo);
            this.Controls.Add(this.bg_scrolling);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScruffyMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scruffy The Pursurer of Sausages";
            this.Load += new System.EventHandler(this.ScruffyMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrufflogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg_scrolling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bg_scrolling;
        private System.Windows.Forms.Timer timer_scroll;
        private System.Windows.Forms.PictureBox scrufflogo;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_highscore;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btnsound;
        private System.Windows.Forms.Button btnminimize;
        private AxWMPLib.AxWindowsMediaPlayer axBackgroundMusic;
    }
}