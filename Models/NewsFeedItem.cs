using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihbiproject.Models
{
    public class NewsFeedItem
    {
        public string From { get; set; }
        public string Created_time { get; set; }
        public string Message { get; set; }
        public string Picture { get; set; }
		public string Place { get; set; }
		public string Story { get; set; }
        public string URI { get; set; }
    }
}
