using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Common
{
    public static class InputRules
    {
        public static string LoginPattern => "^[a-zA-Z0-9]{4,12}$";
        public static string PasswordPattern => "^[a-zA-Z0-9]{8,16}$";
    }
}
