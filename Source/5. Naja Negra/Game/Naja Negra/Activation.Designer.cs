namespace Naja_Negra
{
    partial class Activation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Activation));
            this.idBox = new System.Windows.Forms.TextBox();
            this.serialBox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(51, 86);
            this.idBox.MaxLength = 9;
            this.idBox.Name = "idBox";
            this.idBox.ReadOnly = true;
            this.idBox.Size = new System.Drawing.Size(140, 20);
            this.idBox.TabIndex = 0;
            this.idBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialBox
            // 
            this.serialBox.Location = new System.Drawing.Point(51, 112);
            this.serialBox.MaxLength = 9;
            this.serialBox.Name = "serialBox";
            this.serialBox.Size = new System.Drawing.Size(140, 20);
            this.serialBox.TabIndex = 1;
            this.serialBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serialBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialBox_KeyDown);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(51, 138);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(140, 23);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Activate";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // background
            // 
            this.background.BackgroundImage = global::Naja_Negra.Properties.Resources.background;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(245, 175);
            this.background.TabIndex = 3;
            this.background.TabStop = false;
            this.background.Paint += new System.Windows.Forms.PaintEventHandler(this.background_Paint);
            // 
            // Activation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(245, 175);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Activation";
            this.Text = "Activation";
            this.Load += new System.EventHandler(this.Activation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox serialBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.PictureBox background;
    }
}