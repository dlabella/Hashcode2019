using System.Collections.Generic;

namespace Hashcode2019.Interfaces
{
    public interface ISlide
    {
        HashSet<string> Tags {get;}
        int? Sequence { get; set; }
    }
}