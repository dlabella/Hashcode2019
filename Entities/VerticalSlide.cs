using System.Collections.Generic;
using System.Linq;

namespace Hashcode2019.Entities
{
    public class VerticalSlide:Interfaces.ISlide
    {
        public int? Sequence { get; set; }
        public HashSet<string> Tags{get;internal set;}
        public Photo PhotoA { get; set; }
        public Photo PhotoB { get; set; }
        public VerticalSlide(){

        }
        public VerticalSlide(Photo photoA, Photo photoB){
            PhotoA = photoA;
            PhotoB = photoB;
            List<string> tags = new List<string>();
            tags.AddRange(photoA.Tags);
            tags.AddRange(photoB.Tags);
            this.Tags=tags.Distinct().ToHashSet();
        }
        public override string ToString()
        {
            return $"{PhotoA.Index.ToString()} {PhotoB.Index.ToString()}";
        }
    }
}