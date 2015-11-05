using System;

namespace ihbiproject.Models
{
    public class MapEvent
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FbId { get; set; }
        public string FbURI { get { return String.Format("fb://event/{0}/", FbId); } set { FbId = value; } }
        public string WebURI { get { return String.Format("http://facebook.com/events/{0}/", FbId); } set { WebURI = value; } }
        public DateTime StartTime { get; set; }
    }
}
