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
    public partial class EditPersonForm : Form
    {
        public event Action<PersonViewModel> EditPerson;

        PersonViewModel person;
        public EditPersonForm(PersonViewModel editPerson)
        {
            InitializeComponent();
            person = editPerson;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            person.FirstName = tbFirstName.Text;
            EditPerson?.Invoke(person);
        }
    }
}
