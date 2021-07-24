using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class LoginForm : Form
    {
        Dictionary<string, string> validationPatterns = new Dictionary<string, string>
        {
            { "Login", InputRules.LoginPattern },
            { "Password", InputRules.PasswordPattern }
        };
        Control[] inputControls;
        public LoginForm()
        {
            InitializeComponent();
            inputControls = new Control[] { tbLogin, tbPassword };

            InputFieldsValidation();
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            // Запуск новой формы

            MainForm mainForm = new MainForm(this, new UserViewModel { Login = tbLogin.Text })
            {
                StartPosition = FormStartPosition.CenterScreen,
            };

            // запуск формы в модальном режиме
            // mainForm.ShowDialog();
            // запуск формы в не модальном режиме
            mainForm.Show();
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            InputFieldsValidation();
        }

        private void InputFieldsValidation()
        {
            btnLogin.Enabled = inputControls.All(ctrl =>
            {
                string name = ctrl.Tag.ToString();
                string pattern = validationPatterns[name];
                return Regex.IsMatch(ctrl.Text, pattern);
            });
        }
    }
}
