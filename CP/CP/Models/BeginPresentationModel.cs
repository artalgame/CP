using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CP.Models
{
    public class BeginPresentationModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Имя быть более {2} и менее {1} символов!", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя презентации")]
        public string PresentationName { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Информация о презентации должна быть не более {2} символов", MinimumLength = 0)]
        [DataType(DataType.Text)]
        [Display(Name = "Информация о презентации")]
        public string About { get; set; }

        public DateTime TimeOfCreate { get; set; }
        public Guid PresentationId { get; set; }
        public Guid UserId { get; set; }

        public static BeginPresentationModel CreateFromPresentation(Presentation presentation)
        {
            var presentationModel = new BeginPresentationModel();
            presentationModel.About = presentation.About;
            presentationModel.PresentationId = presentation.PresentationId;
            presentationModel.PresentationName = presentation.Name;
            presentationModel.TimeOfCreate = presentation.DateOfCreate;
            presentationModel.UserId = presentation.UserId;

            return presentationModel;
        }
    }
}