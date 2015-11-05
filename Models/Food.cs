using System;

namespace ihbiproject.Models
{
	public class Food
	{
		public int user_id { get; set; }
		public int calcium { get; set; }
		public int fruit { get; set; }
		public int vegetable { get; set; }
		public int water { get; set; }
		//public DateTime date { get; set; }
		public string date { get; set; }

		public Food ()
		{

		}

		public override string ToString ()
		{
			return string.Format ("[Food: user_id={0}, calcium={1}, fruit={2}, vegetable={3}, water={4}, date={5}]", user_id, calcium, fruit, vegetable, water, date);
		}
	}
}

