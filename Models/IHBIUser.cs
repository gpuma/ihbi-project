using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihbiproject.Models
{
    public class IHBIUser
    {
        //necessary for Azure
		public string Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
        public string Username { get; set; }
    }
}
