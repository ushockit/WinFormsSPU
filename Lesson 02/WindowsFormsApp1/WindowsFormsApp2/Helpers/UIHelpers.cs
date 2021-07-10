using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace WindowsFormsApp2.Helpers
{
    public static class UIHelpers
    {
        public static void ShowPreloader(Form form)
        {
            const int WIDTH = 500;
            const int HEIGHT = 500;

            PictureBox preloader = new PictureBox
            {
                Width = WIDTH,
                Height = HEIGHT,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile("Images\\preloader.gif"),
                Name = "preloader",
                Location = new Point
                {
                    X = (form.Width - WIDTH) / 2,
                    Y = (form.Height - HEIGHT) / 2
                },
            };

            form.Controls.Add(preloader);
        }
        public static void HidePreloader(Form form)
        {
            var preloader = FindControlByName(form.Controls, "preloader");
            form.Controls.Remove(preloader);
        }

        public static Control FindControlByName(ControlCollection collection, string name)
        {
            var srchRes = collection.Find(name, false);
            Control control = null;
            if (srchRes.Length > 0)
            {
                control = srchRes.First();
            }
            return control;
        }
    }
}
