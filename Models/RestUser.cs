using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihbiproject.Models
{
    public class RestUser
    {
        //necessary for Azure
		public string id { get; set; }
		public string email { get; set; }
		public string password { get; set; }
        public string username { get; set; }

		public override String ToString()
		{
			return ("Name: " + username + " retrieved from server");
		}
    }


}
