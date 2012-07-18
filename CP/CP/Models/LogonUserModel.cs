using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CP.Models
{
    public class LogonUserModel
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Логин")]
        [StringLength(256, ErrorMessage = "Длина логина должна быть более {2} и менее {1} символов!", MinimumLength = 5)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть более {2} и менее {1} символов!", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool Remember { get; set; }

    }
}