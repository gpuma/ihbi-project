using System;

namespace ihbiproject
{
	public class Exercise
	{
		public int? Id { get; set; }
		public Nullable<int> user_id { get; set; }
		public Nullable<int> stretching { get; set; }
		public Nullable<int> pelvic { get; set; }
		public string minutes { get; set; }
		public string type { get; set; }
		public Nullable<System.DateTime> date { get; set; }

		public Exercise ()
		{
		}
	}
}

