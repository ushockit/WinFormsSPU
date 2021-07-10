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
using WindowsFormsApp2.Helpers;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<string> items = new List<string> { "item 1", "item 2", "item 3" };
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

            int seconds = 5;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                System.Windows.Forms.Timer t = s as System.Windows.Forms.Timer;

                if (seconds == 0)
                {
                    t.Stop();
                    MessageBox.Show("Hello");
                }
                seconds--;
            };
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunAsyncAction(() =>
            {
                // TODO: Load data
                Thread.Sleep(2000);
                BeginInvoke(new Action(() =>
                {
                    UIHelpers.HidePreloader(this);
                    LoadDataToList(items);
                    SetPanelVisible(true);
                }));
            });
        }

        private void SetPanelVisible(bool visible)
        {
            panel.Visible = visible;
        }
        private void LoadDataToList(List<string> items)
        {
            lbItems.DataSource = null;
            lbItems.DataSource = items;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex != ListBox.NoMatches)
            {
                RunAsyncAction(() =>
                {
                    // TODO: Remove item
                    Thread.Sleep(1000);
                    BeginInvoke(new Action(() =>
                    {
                        UIHelpers.HidePreloader(this);
                        items.RemoveAt(lbItems.SelectedIndex);
                        LoadDataToList(items);
                        SetPanelVisible(true);
                    }));
                });
            }
        }

        private void RunAsyncAction(Action action)
        {
            UIHelpers.ShowPreloader(this);
            SetPanelVisible(false);
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) => action();
            worker.RunWorkerAsync();
        }
    }
}
