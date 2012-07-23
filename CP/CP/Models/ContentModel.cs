using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CP.Models
{
    public class ContentModel
    {
        public string Font { get; set; }
        public string FontColor { get; set; }
        public string FontSize { get; set; }
        public string FontStyle { get; set; }

        [StringLength(500, ErrorMessage = "Содержание слайда должно быть не более {1}!", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Содержание слайда ")]
        public string Text { get; set; }
        public Guid ContentId { get; set; }

        public static ContentModel CreateFromContent(Content content)
        {
            var contentModel = new ContentModel();

            contentModel.Font = content.Font;
            contentModel.FontColor = content.FontColor;
            contentModel.FontSize = content.FontSize.ToString();
            contentModel.FontStyle = content.FontStyle;
            contentModel.Text = content.Text;
            contentModel.ContentId = content.ContentId;

            return contentModel;
        }
    }
}