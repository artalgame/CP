using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public partial class Slide
    {
        public static Slide CreateFromSlideModel(SlideModel slideModel)
        {
            var slide = new Slide()
            {
                Content = Content.GetFromContentModel(slideModel.ContentOfSlide),
                ContentId = slideModel.ContentOfSlide.ContentId,
                FonColor = slideModel.FonColor,
                PresentationId = slideModel.PresentationId,
                SlideId = slideModel.SlideId,
                SlideNumber = slideModel.SlideNumber,
                Title = Title.CreateFromTitleModel(slideModel.TitleOfSlide),
                TitleId = slideModel.TitleOfSlide.TitleId
            };
            return slide;
        }
    }
}