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
		//public Nullable<System.DateTime> date { get; set; }
		public string date { get; set; }

		public Exercise ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Exercise: Id={0}, user_id={1}, stretching={2}, pelvic={3}, minutes={4}, type={5}, date={6}]", Id, user_id, stretching, pelvic, minutes, type, date);
		}
	}
}

