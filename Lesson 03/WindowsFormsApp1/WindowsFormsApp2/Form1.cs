using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonOpenFileDialogClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = "C:\\"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileStream = dlg.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    tbContent.Text = reader.ReadToEnd();
                }
            }
        }

        private void ButtonOpenFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] filesPaths = Directory.GetFiles(dlg.SelectedPath);
                tbContent.Text = string.Join("\r\n", filesPaths);
            }
        }

        private void BtnOpenFontDialogClick(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog
            {
                Font = btnOpenFontDlg.Font,
                ShowColor = true,
                Color  = btnOpenFontDlg.ForeColor
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btnOpenFontDlg.Font = dlg.Font;
                btnOpenFontDlg.ForeColor = dlg.Color;
            }
        }

        private void ButtonOpenColorClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                AllowFullOpen = true,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ;
            }
        }

        private void ButtonSaveFileDialogClick(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ;
            }
        }
    }
}
