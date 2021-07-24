using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class AddNewPersonForm : Form
    {
        // public PersonViewModel NewPerson { get; private set; }
        public event Action<PersonViewModel> CreatePerson;
        public AddNewPersonForm()
        {
            InitializeComponent();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            var person = new PersonViewModel
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Birth = datePickerBirth.Value
            };
            // Уведомление о создании нового person`а
            CreatePerson?.Invoke(person);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
