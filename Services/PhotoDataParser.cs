using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hashcode2019.Entities;

namespace Hashcode2019.Services
{
    public class PhotoDataParser
    {
        public async Task<List<Photo>> Parse(string file)
        {
            int idx = 0;
            int photoCount = 0;
            bool firstLine = true;
            List<Photo> items = null;
            using (var rdr = new StreamReader(file))
            {
                while (!rdr.EndOfStream)
                {
                    var line = await rdr.ReadLineAsync();
                    if (firstLine)
                    {
                        photoCount = int.Parse(line);
                        items = new List<Photo>(photoCount);
                        firstLine = false;
                    }
                    else
                    {
                        var photo = ParsePhoto(line);
                        photo.Index = idx;
                        items.Add(photo);
                        idx++;
                    }
                }
            }
            return items;
        }

        private Photo ParsePhoto(string photoData)
        {
            var data = photoData.Split(" ");
            var photo = new Photo
            {
                Orientation = data[0][0]
            };
            int count = int.Parse(data[1]);
            photo.Tags = new HashSet<string>(count);
            for (var i = 0; i < count; i++)
            {
                photo.Tags.Add(data[i + 2]);
            }
            return photo;
        }
    }
}