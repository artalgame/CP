using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public class SlideModel
    {
        public Presentation CurrentPresentation { get; set; }
        public Title TitleOfSlide { get; set; }
        public Content ContentOfSlide { get; set; }
        public string FonColor { get; set; }
        public int SlideNumber { get; set; }

        public SlideModel()
        {
            ContentOfSlide = new Content();
            TitleOfSlide = new Title();
            FonColor = "ffffff";
            SlideNumber = 0;
        }
    }
}