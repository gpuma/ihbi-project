using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject.Data;

namespace ihbiproject.ViewModels
{
    public class WellnessViewModel
    {
        public double SleepHours { get; set; }
        public Dictionary<string, string> moods { get; set; }
        public string SelectedMood { get; set; }
        public WellnessViewModel()
        {
            SleepHours = CONST.DEFAULT_SLEEP;
            moods = db.Moods;
        }
    }
}
