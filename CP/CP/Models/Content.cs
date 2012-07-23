using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.Models
{
    public partial class Content
    {
        public static Content GetFromContentModel(ContentModel contentModel)
        {
            var content = new Content() { 
            ContentId = contentModel.ContentId,
            Font = contentModel.Font,
            FontColor = contentModel.FontColor,
            FontSize = Int32.Parse(contentModel.FontSize),
            FontStyle = contentModel.FontStyle,
            Text = contentModel.Text
            };
            return content;
        }
    }
}