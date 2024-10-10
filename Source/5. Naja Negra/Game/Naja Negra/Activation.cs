namespace Naja_Negra
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Activation : Form
    {
        private readonly License license;

        public Activation(License license)
        {
            this.license = license;
            InitializeComponent();
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            idBox.Text = license.getID();
        }

        private void serialBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkButton_Click(sender, e);
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (license.Activate(serialBox.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show($"Invalid activation code", "Naja Negra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Properties.Resources.tail, new Rectangle(35, 35, 35, 35));
            g.DrawImage(Properties.Resources.body, new Rectangle(70, 35, 35, 35));
            g.DrawImage(Properties.Resources.head, new Rectangle(105, 35, 35, 35));
            g.DrawImage(Properties.Resources.apple, new Rectangle(175, 35, 35, 35));
        }
    }
}
