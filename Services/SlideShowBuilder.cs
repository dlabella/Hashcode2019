using Hashcode2019.Entities;
using Hashcode2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashcode2019.Services
{
    public class SlideShowBuilder
    {
        public List<ISlide> BuildVerticalSlides(Photo[] photos)
        {
            int photoProcessed = 0;
            var vSlides = new List<ISlide>();

            int groupIdx = 0;

            var itemCount = photos.Count(x => x.Orientation == 'V');

            while (photoProcessed != itemCount)
            {
                var item = photos.FirstOrDefault(x => x.Slide == null && x.Orientation == 'V');
                var match = FindClosestPhoto(photos, item, 'V');
                if (match != null)
                {
                    item.Slide = groupIdx;
                    match.Slide = groupIdx;
                    vSlides.Add(new VerticalSlide(item, match));
                    groupIdx++;
                    photoProcessed += 2;
                }

            }
            return vSlides;
        }

        public List<ISlide> BuildHorizontalSlides(Photo[] photos)
        {
            var hSlides = new List<ISlide>();
            int groupIdx = 0;

            foreach (var item in photos.Where(x => x.Orientation == 'H'))
            {
                hSlides.Add(new HorizontalSlide(item));
                item.Slide = groupIdx++;
            }
            return hSlides;
        }

        public SlideShow BuildSlideShow(Photo[] photos)
        {
            var hSlides = BuildHorizontalSlides(photos);
            var vSlides = BuildVerticalSlides(photos);
            var slides = new List<ISlide>();
            slides.AddRange(hSlides);
            slides.AddRange(vSlides);
            var slideShow = new SlideShow();
            int seq = 0;

            while (slides.Any())
            {
                var item = slides.FirstOrDefault(x => x.Sequence == null);
                var nextItem = FindClosestSlide(slides, item);
                item.Sequence = seq++;
                slideShow.Slides.Add(item);
                slides.Remove(item);
                if (nextItem != null)
                {
                    nextItem.Sequence = seq++;
                    slideShow.Slides.Add(nextItem);
                    slides.Remove(nextItem);
                }
                System.Diagnostics.Debug.WriteLine($"SEQ: {seq}");
            }
            return slideShow;
        }

        public Photo FindClosestPhoto(Photo[] photos, Photo photo, char orientation)
        {
            Photo closestMatch = null;
            int closestCount = 0;
            foreach (var item in photos.Where(x => x.Slide == null && x.Orientation == orientation))
            {
                if (item == photo)
                {
                    continue;
                }
                var tagsShared = photo.Tags.Intersect(item.Tags).Count();
                if (tagsShared > closestCount || closestMatch == null)
                {
                    closestCount = tagsShared;
                    closestMatch = item;
                }
            }
            return closestMatch;
        }

        public ISlide FindClosestSlide(List<ISlide> slides, ISlide slide)
        {
            ISlide closestMatch = null;
            int closestCount = 0;
            foreach (var item in slides.Where(x => x.Sequence == null))
            {
                if (item == slide)
                {
                    continue;
                }
                var tagsShared = slide.Tags.Intersect(item.Tags).Count();
                if (tagsShared > closestCount || closestMatch == null)
                {
                    closestCount = tagsShared;
                    closestMatch = item;
                }
            }
            return closestMatch;
        }
    }
}
