using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Remont_Kursovoi.Models;

namespace Remont_Kursovoi.Controllers
{
    public class LoginModelController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: LoginModel
        public ActionResult LoginModel()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginModel(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               Работники пользователи = db.Работники.ToList().Find(x => x.Логин == model.login);

                if (пользователи != null)
                {

                    string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(model.password + пользователи.Соль, "SHA1");
                    if (пользователи.Пароль == hash)
                    {
                        FormsAuthentication.SetAuthCookie(model.login, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин или пароль");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                }

            }
            return View(model);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Работники");
        }
    }
}