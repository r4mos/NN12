namespace Naja_Negra
{
    partial class Game
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.PictureBox();
            this.main = new System.Windows.Forms.PictureBox();
            this.scoreImage = new System.Windows.Forms.PictureBox();
            this.scoreText = new System.Windows.Forms.Label();
            this.credits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreImage)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(117)))), ((int)(((byte)(44)))));
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(615, 70);
            this.menu.TabIndex = 0;
            this.menu.TabStop = false;
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(209)))), ((int)(((byte)(73)))));
            this.main.BackgroundImage = global::Naja_Negra.Properties.Resources.background;
            this.main.Location = new System.Drawing.Point(10, 80);
            this.main.Margin = new System.Windows.Forms.Padding(0);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(595, 525);
            this.main.TabIndex = 1;
            this.main.TabStop = false;
            this.main.Paint += new System.Windows.Forms.PaintEventHandler(this.Background_Paint);
            // 
            // scoreImage
            // 
            this.scoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(117)))), ((int)(((byte)(44)))));
            this.scoreImage.Image = global::Naja_Negra.Properties.Resources.apple;
            this.scoreImage.Location = new System.Drawing.Point(10, 19);
            this.scoreImage.Margin = new System.Windows.Forms.Padding(0);
            this.scoreImage.Name = "scoreImage";
            this.scoreImage.Size = new System.Drawing.Size(38, 38);
            this.scoreImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scoreImage.TabIndex = 2;
            this.scoreImage.TabStop = false;
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(117)))), ((int)(((byte)(44)))));
            this.scoreText.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.ForeColor = System.Drawing.Color.White;
            this.scoreText.Location = new System.Drawing.Point(51, 23);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(29, 32);
            this.scoreText.TabIndex = 3;
            this.scoreText.Text = "0";
            // 
            // credits
            // 
            this.credits.AutoSize = true;
            this.credits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(117)))), ((int)(((byte)(44)))));
            this.credits.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits.ForeColor = System.Drawing.Color.White;
            this.credits.Location = new System.Drawing.Point(500, 27);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(103, 28);
            this.credits.TabIndex = 4;
            this.credits.Text = "#nn12ed";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(615, 616);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.scoreImage);
            this.Controls.Add(this.main);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Naja Negra";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox menu;
        private System.Windows.Forms.PictureBox main;
        private System.Windows.Forms.PictureBox scoreImage;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Label credits;
    }
}

