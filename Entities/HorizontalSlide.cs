using System.Collections.Generic;

namespace Hashcode2019.Entities
{
    public class HorizontalSlide:Interfaces.ISlide
    {
        public Photo Photo { get; set; }
        public HashSet<string> Tags{get;internal set;}
        public int? Sequence { get; set; }

        public HorizontalSlide(){

        }
        public HorizontalSlide(Photo photo){
            this.Tags=photo.Tags;
            Photo = photo;
        }
        public override string ToString()
        {
            return Photo.Index.ToString();
        }
    }
}