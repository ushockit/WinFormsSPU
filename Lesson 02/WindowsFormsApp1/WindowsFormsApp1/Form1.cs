using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Extensions;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> items = new List<string> { "Item 1", "Item 2", "Item 3" };
        List<Person> people = new List<Person>
        {
            new Person { Id = 1, FirstName = "Vasya", LastName = "Pupkin", Birth = DateTime.Now },
            new Person { Id = 2, FirstName = "Petya", LastName = "Sidorov", Birth = DateTime.Now },
            new Person { Id = 3, FirstName = "Kolya", LastName = "Ivanov", Birth = DateTime.Now },
            new Person { Id = 4, FirstName = "Masha", LastName = "Stepanova", Birth = DateTime.Now },
        };
        public Form1()
        {
            InitializeComponent();
            // добавление элементов в список
            //lbItems.Items.AddRange(items.ToArray());
            lbItems.UpdateList(items);
            lbPeople.UpdateList(people);
            //lbItems.DataSource = items;
            cbPositions.UpdateList(items);
            checkedListBox.Items.AddRange(items.ToArray());
            domainUpDown1.Items.AddRange(new string[] { "Item 5", "Item 2", "Item 6", "Item 1", "Item 4", "Item 3" });
            domainUpDown1.Sorted = true;
        }

        private void LbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = $"{lbItems.SelectedIndex} - {lbItems.SelectedItem}";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            items.Add("New item");
            lbItems.UpdateList(items);
            // убираем привязку
            // lbItems.DataSource = null;
            // повторная привязка
            // lbItems.DataSource = items;

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            // элемент выбран
            if (lbItems.SelectedIndex != ListBox.NoMatches)
            {
                // удаление эл-та по индексу
                items.RemoveAt(lbItems.SelectedIndex);
                lbItems.UpdateList(items);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // элемент выбран
            if (lbItems.SelectedIndex != ListBox.NoMatches)
            {
                items[lbItems.SelectedIndex] = "Updated";
                lbItems.UpdateList(items);
            }
        }

        private void LbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPeople.SelectedIndex != ListBox.NoMatches)
            {
                Person person = lbPeople.SelectedItem as Person;
                person.FirstName = "Updated";

                lbPeople.UpdateList(people);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cbPositions.Enabled = checkBox.Checked;
            // if (checkBox.Checked)
            if (checkBox.CheckState == CheckState.Checked)
            {
                // TODO: Some action
                checkBox.Text = "Disable";
            }
            else if (checkBox.CheckState == CheckState.Unchecked)
            {
                checkBox.Text = "Enable";
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ;
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            ;
        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // преобразование списка выбранных элементов в строку
            Text = string.Join(",", checkedListBox.CheckedItems.OfType<string>());
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Text = numericUpDown1.Value.ToString();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Text = trackBar1.Value.ToString();
            progressBar1.Value = trackBar1.Value;
        }

        private void BtnSetImage_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(tbImgPath.Text);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            pbDownload.Value = 0;
            worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            const int MAX = 100;
            while (pbDownload.Value < MAX)
            {
                int rndVal = rnd.Next(5, 10);
                if (pbDownload.Value + rndVal <= MAX)
                {
                    // обращение к потоку в котором был создан pbDownload
                    pbDownload.BeginInvoke(new Action(() => 
                    {
                        pbDownload.Value += rndVal;
                    }));
                }
                else
                {
                    // обращение к потоку в котором был создан pbDownload
                    pbDownload.BeginInvoke(new Action(() =>
                    {
                        pbDownload.Value = MAX;
                    }));
                }
                Thread.Sleep(250);
            }
        }
    }
}
