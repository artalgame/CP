using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CP.Models
{
    public class TitleModel
    {
        public string Font { get; set; }
        public string FontColor { get; set; }
        public string FontSize { get; set; }
        public string FontStyle { get; set; }

        [StringLength(100, ErrorMessage = "Заголовок слайда должно быть не более {1}!", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок слайда")]
        public string Text { get; set; }

        public Guid TitleId { get; set; }

        public static TitleModel CreateFromTitle(Title title)
        {
            var titleModel = new TitleModel();

            titleModel.Font = title.Font;
            titleModel.FontColor = title.FontColor;
            titleModel.FontSize = title.FontSize.ToString();
            titleModel.FontStyle = title.FontStyle;
            titleModel.Text = title.Text;
            titleModel.TitleId = title.TitleId;

            return titleModel;
        }
    }
}