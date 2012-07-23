using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace CP.Models
{
    public class SlideModel
    {
        public Guid PresentationId { get; set; }
        public TitleModel TitleOfSlide { get; set; }
        public ContentModel ContentOfSlide { get; set; }
        public string FonColor { get; set; }
        public int SlideNumber { get; set; }
        public Guid SlideId { get; set; }

        public SlideModel()
        {
            ContentOfSlide = new ContentModel() { ContentId = Guid.NewGuid()};
            TitleOfSlide = new TitleModel() { TitleId = Guid.NewGuid()};
            FonColor = "ffffff";
            PresentationId = Guid.Empty;
            SlideNumber = 0;
            SlideId = Guid.NewGuid();
        }
        public static SlideModel GetSlideModelFromDBSlide(Slide slide)
        {
            var slideModel = new SlideModel();
            slideModel.ContentOfSlide = ContentModel.CreateFromContent(slide.Content);
            slideModel.TitleOfSlide = TitleModel.CreateFromTitle(slide.Title);
            slideModel.FonColor = slide.FonColor;
            slideModel.SlideNumber = slide.SlideNumber;
            slideModel.PresentationId = slide.PresentationId;
            slideModel.SlideId = slide.SlideId;
            return slideModel;
            
        }
    }
}