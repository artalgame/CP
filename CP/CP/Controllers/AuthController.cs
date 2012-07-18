using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Models;
using System.Web.Security;

namespace CP.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Index()
        {
            return RedirectToAction("Logon", "Auth");
        }

        public ActionResult LogOn()
        {
            if (Request.IsAuthenticated)
                RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogonUserModel user)
        {
            if (ModelState.IsValid)
            {
                // Проверяем логин и пароль пользователя
                if (Membership.ValidateUser(user.Login, user.Password))
                {
                    // Если все верно, ставим ему куки
                    FormsAuthentication.SetAuthCookie(
                            user.Login,
                            user.Remember
                        );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Иначе показываем ошибку
                    ModelState.AddModelError("", "Имя пользователя или пароль не верны!");
                }
            }
            return View(user);
        }

        public ActionResult Register()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel user)
        {
            if (ModelState.IsValid) // Проверяем модель на валидность
            {
                // Статус регистрации
                MembershipCreateStatus createStatus;

                //Создаем пользователя
                var newUser = Membership.CreateUser(user.Login, user.Password, user.Email, null, null, true, null, out createStatus);

                // Проверяем результат регистрации
                if (createStatus == MembershipCreateStatus.Success)
                {
                    // Если успешно, авторизуем его
                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    // И создаем нашему пользователю пустой профиль в БД 
                    SimPresEntities model = new SimPresEntities();
                    model.Users.AddObject(
                        new User()
                        {
                            UserId = (Guid)newUser.ProviderUserKey,
                            Login = user.Login,
                            About = "",
                            Email = user.Email
                        });
                    //Фиксируем изменения в БД
                    model.SaveChanges();

                    // Если все прошло успешно, перенаправляем его на редактирование профиля
                    return RedirectToAction("Home", "Index");
                }
                else
                {
                    switch (createStatus)
                    {
                        case MembershipCreateStatus.InvalidEmail:
                            ModelState.AddModelError("Email", "Неправильный email адрес!");
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            ModelState.AddModelError("Login", "Данный логин занят!");
                            break;
                        case MembershipCreateStatus.DuplicateEmail:
                            ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован!");
                            break;
                        default:
                            ModelState.AddModelError("", "При регистрации возникла ошибка, попробуйте позже!");
                            break;
                    }
                }
            }
            // Передаем в отображение нашего пользователя, иначе поля окажутся пустыми
            return View(user);
        }

    }
}
