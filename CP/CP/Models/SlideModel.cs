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
        public Title TitleOfSlide { get; set; }
        public Content ContentOfSlide { get; set; }
        public string FonColor { get; set; }
        public int SlideNumber { get; set; }
        public string TitleFontSize{get;set;}
        public string ContentFontSize{get;set;}

        public SlideModel()
        {
            ContentOfSlide = new Content() { ContentId = Guid.NewGuid()};
            TitleOfSlide = new Title() { TitleId = Guid.NewGuid()};
            FonColor = "ffffff";
            PresentationId = Guid.Empty;
            SlideNumber = 0;
            ContentFontSize = "";
            TitleFontSize = "";
        }
    }
}