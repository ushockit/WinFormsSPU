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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class MainForm : Form
    {
        LoginForm loginForm;
        UserViewModel user;
        List<PersonViewModel> people;
        public MainForm(LoginForm loginForm, UserViewModel user)
        {
            InitializeComponent();

            this.loginForm = loginForm;
            this.user = user;
            Init();
        }

        private void Init()
        {
            people = new List<PersonViewModel>
            {
                new PersonViewModel { Id = 1, FirstName = "First name 1", LastName = "Last name 1", Birth = new DateTime(1990, 10, 10) },
                new PersonViewModel { Id = 2, FirstName = "First name 2", LastName = "Last name 2", Birth = new DateTime(1985, 01, 12) },
                new PersonViewModel { Id = 3, FirstName = "First name 3", LastName = "Last name 3", Birth = new DateTime(1979, 05, 10) },
                new PersonViewModel { Id = 4, FirstName = "First name 4", LastName = "Last name 4", Birth = new DateTime(1987, 08, 24) },
            };
            UpdatePeopleList();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            loginForm.Hide();
            this.Text = user.Login;
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void BtnAddNewPersonClick(object sender, EventArgs e)
        {
            AddNewPersonForm form = new AddNewPersonForm
            { 
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.CreatePerson += (newPerson) =>
            {
                people.Add(newPerson);
                UpdatePeopleList();
            };

            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    people.Add(form.NewPerson);
            //    UpdatePeopleList();
            //}


            form.ShowDialog();

        }

        private void UpdatePeopleList()
        {
            lbPeople.DataSource = null;
            lbPeople.DataSource = people;
        }

        private void LbPeopleMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbPeople.SelectedIndex != ListBox.NoMatches)
            {
                EditPersonForm form = new EditPersonForm(people[lbPeople.SelectedIndex])
                {
                    Owner = this,
                    StartPosition = FormStartPosition.CenterParent
                };
                form.EditPerson += (person) =>
                {
                    Text = $"The person with id = {person.Id} has updated";
                    UpdatePeopleList();
                };
                form.Show();
            }
        }
    }
}