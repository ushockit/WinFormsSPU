using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LblText_Click(object sender, EventArgs e)
        {
            ;
        }

        private void BtnMoveToLeftLbl_Click(object sender, EventArgs e)
        {
            lblText.Location = new Point(lblText.Location.X + 10, lblText.Location.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    lblText.Location = new Point(lblText.Location.X + 10, lblText.Location.Y);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Remove(btnMoveToLeftLbl);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Text = tbText.Text;
        }

        private void TbText_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!"0123456789\b".Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tbText.Text = numericUpDown1.Value.ToString();
        }

        private void ButtonNum_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Text = btn.Text;
        }
    }
}
