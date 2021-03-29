using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Remont_Kursovoi;

namespace Remont_Kursovoi.Controllers
{
    public class РаботникиController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Работники

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Работники.ToList());
            
        }

        [HttpPost]
        public ActionResult notlate_info(int number)
        {
            List<notlate_Result> notlate_Results = db.notlate(number).ToList();
            return View(notlate_Results);
        }



        // GET: Работники/Create
        public ActionResult LogUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogUp([Bind(Include = "ID_работника,Должность,Фамилия,Имя,Отчество,Логин,Пароль")] Работники работники)
        {
            Random random = new Random();
            if (ModelState.IsValid)
            {
                Работники сотрудник = db.Работники.ToList().Find(x => x.Логин == работники.Логин);
                if (сотрудник == null)
                {
                    string Соль1 = Convert.ToString(random.Next(1000, 10000));
                    string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(работники.Пароль + Соль1, "SHA1");
                    db.Работники.Add(new Работники
                    {
                        ID_работника = Guid.NewGuid(),
                        Должность = работники.Должность,
                        Фамилия = работники.Фамилия,
                        Имя = работники.Имя,
                        Отчество = работники.Отчество,
                        Пароль = hash,
                        Логин = работники.Логин,
                        Соль = Int32.Parse(Соль1)

                    });
                    db.SaveChanges();
                    сотрудник = db.Работники.ToList().Find(x => x.Логин == работники.Логин);
                    if (сотрудник != null)
                    {
                        FormsAuthentication.SetAuthCookie(работники.Логин, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такой сотрудник уже зарегистрирован");
                }
            }
            return View();
        }


        // GET: Работники/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работники работники = db.Работники.Find(id);
            if (работники == null)
            {
                return HttpNotFound();
            }
            return View(работники);
        }

        // POST: Работники/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_работника,Должность,Фамилия,Имя,Отчество,Логин,Пароль")] Работники работники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(работники).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(работники);
        }

        // GET: Работники/Delete/5
      
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работники работники = db.Работники.Find(id);
            if (работники == null)
            {
                return HttpNotFound();
            }
            return View(работники);
        }
  

        // POST: Работники/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(Guid id)
        {
            Работники работники = db.Работники.Find(id);
            db.Работники.Remove(работники);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Exception");
            }
           
        }

        public ActionResult Exception()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Actions()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
