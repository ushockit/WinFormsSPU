using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        const int COUNT_CELLS = 8;
        Label[,] cells = new Label[COUNT_CELLS, COUNT_CELLS];
        public Form1()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            for (int i = 0; i < COUNT_CELLS; i++)
            {
                for (int j = 0; j < COUNT_CELLS; j++)
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Text = "Hello",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Black
                    };
                    grid.Controls.Add(label);
                    cells[i, j] = label;
                    label.Click += (s, e) =>
                    {
                        label.BackColor = Color.Gold;
                    };


                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        label.BackColor = Color.Black;
                    }
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        label.BackColor = Color.Brown;
                    }
                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        label.BackColor = Color.Brown;
                    }
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        label.BackColor = Color.Black;
                    }
                }
            }
        }
    }
}
