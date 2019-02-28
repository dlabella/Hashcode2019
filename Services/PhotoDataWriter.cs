using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hashcode2019.Entities;

namespace Hashcode2019.Services
{
    public class PhotoDataWriter
    {
        public async Task Write(string filename, SlideShow slideShow)
        {
            using(var sw = new StreamWriter($"Samples/{filename}.out"))
            {
                sw.WriteLine(slideShow.Slides.Count);
                foreach(var slide in slideShow.Slides)
                {
                    await sw.WriteLineAsync(slide.ToString());
                }
            }
        }
    }
}