using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CP.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Ваш логин")]
        [StringLength(256, ErrorMessage = "Длина логина должна быть более {2} и менее {1} символов!", 
         MinimumLength = 5)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "E-mail")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Неправильный email адрес!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть более {2} и менее {1} символов!", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }

    }
}