using System;

namespace ihbiproject
{
	public class Wellness
	{
		public int? Id { get; set; }
		public int user_id { get; set; }
		public double sleep { get; set; }
		public string mood { get; set; }
		public DateTime date { get; set; }

		public Wellness ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Wellness: Id={0}, user_id={1}, sleep={2}, mood={3}, date={4}]", Id, user_id, sleep, mood, date);
		}
	}
}

