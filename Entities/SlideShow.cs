using System.Collections.Generic;

namespace Hashcode2019.Entities
{
    public class SlideShow
    {
        public List<Interfaces.ISlide> Slides {get;set;}
        public SlideShow(){
            Slides=new List<Interfaces.ISlide>();
        }
    }
}