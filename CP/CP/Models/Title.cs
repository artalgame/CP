using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public partial class Title
    {
        public static Title CreateFromTitleModel(TitleModel titleModel)
        {
            var title = new Title()
            {
                Font = titleModel.Font,
                FontColor = titleModel.FontColor,
                FontSize = Int32.Parse(titleModel.FontSize),
                FontStyle = titleModel.FontStyle,
                Text = titleModel.Text,
                TitleId = titleModel.TitleId
            };
            return title;
        }
    }
}