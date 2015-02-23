using System.Collections.Generic;

namespace Books.Core.Services
{
    public class RootObject
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string contributor { get; set; }
        public string day { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public int? start { get; set; }
        public int? end { get; set; }
        public string description { get; set; }
        public int __v { get; set; }
    }
}
