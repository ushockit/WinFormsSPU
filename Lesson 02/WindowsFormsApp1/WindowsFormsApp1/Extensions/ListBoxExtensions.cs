using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Extensions
{
    public static class ListBoxExtensions
    {
        public static void UpdateList<T>(this ListBox list, T items)
        {
            list.DataSource = null;
            list.DataSource = items;
        }
    }
}
