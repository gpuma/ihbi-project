using System;

namespace ihbiproject
{
	public class Exercise
	{
		public int user_id { get; set; }
		public bool stretching { get; set; }
		public bool pelvic { get; set; }
		public int minutes { get; set; }
		public string type { get; set; }
		public DateTime date { get; set; }

		public Exercise ()
		{
		}
	}
}

