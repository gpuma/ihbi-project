using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject.Data;
using ihbiproject.Models;

namespace ihbiproject.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public IHBIUser Login()
        {
            //todo: hash password
            var user = db.GetUser(Username, Password);
            return user;
        }
    }
}
