using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public class CreatedPresentationModel
    {
        public BeginPresentationModel PresentationProperties { get; set; }
        public List<SlideModel> Slides { get; set; }
    }
}