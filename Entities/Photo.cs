using System.Collections.Generic;

namespace Hashcode2019.Entities
{
    public class Photo 
    {
        public int Index { get; set; }
        public char Orientation{get;set;}
        public HashSet<string> Tags{get;set;}
        public int? Slide { get; set; }
    }
}