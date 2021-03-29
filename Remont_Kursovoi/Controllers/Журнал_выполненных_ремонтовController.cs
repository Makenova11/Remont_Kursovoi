using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Remont_Kursovoi;

namespace Remont_Kursovoi.Controllers
{
    public class Журнал_выполненных_ремонтовController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Журнал_выполненных_ремонтов
        [Authorize]
        public ActionResult Index(Guid? id)
        {
            var журнал_выполненных_ремонтов = db.Журнал_выполненных_ремонтов.Include(ж => ж.График_плановых_техобслуживаний).Include(ж => ж.Экземпляры_оборудований).Include(ж => ж.Типы_ремонта);
            return View(журнал_выполненных_ремонтов.ToList());
        }

        // GET: Журнал_выполненных_ремонтов/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Журнал_выполненных_ремонтов журнал_выполненных_ремонтов = db.Журнал_выполненных_ремонтов.Find(id);
            if (журнал_выполненных_ремонтов == null)
            {
                return HttpNotFound();
            }
            return View(журнал_выполненных_ремонтов);
        }

        // GET: Журнал_выполненных_ремонтов/Create
        public ActionResult Create()
        {
            ViewBag.ID_планового_ремонта = new SelectList(db.График_плановых_техобслуживаний, "ID_планового_ремонта", "ID_планового_ремонта");
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Наименование", "Наименование");
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Наименование", "Наименование");
            return View();
        }

        // POST: Журнал_выполненных_ремонтов/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ремонта,Дата_начала,Дата_окончания,ID_планового_ремонта,Код_экземпляра,Код_ремонта,Примечания")] Журнал_выполненных_ремонтов журнал_выполненных_ремонтов)
        {
            if (ModelState.IsValid)
            {
                журнал_выполненных_ремонтов.ID_ремонта = Guid.NewGuid();
                db.Журнал_выполненных_ремонтов.Add(журнал_выполненных_ремонтов);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_планового_ремонта = new SelectList(db.График_плановых_техобслуживаний, "ID_планового_ремонта", "ID_планового_ремонта", журнал_выполненных_ремонтов.ID_планового_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", журнал_выполненных_ремонтов.Код_экземпляра);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Наименование", журнал_выполненных_ремонтов.Код_ремонта);
            return View(журнал_выполненных_ремонтов);
        }

        // GET: Журнал_выполненных_ремонтов/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Журнал_выполненных_ремонтов журнал_выполненных_ремонтов = db.Журнал_выполненных_ремонтов.Find(id);
            if (журнал_выполненных_ремонтов == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_планового_ремонта = new SelectList(db.График_плановых_техобслуживаний, "ID_планового_ремонта", "ID_планового_ремонта", журнал_выполненных_ремонтов.ID_планового_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", журнал_выполненных_ремонтов.Код_экземпляра);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Наименование", журнал_выполненных_ремонтов.Код_ремонта);
            return View(журнал_выполненных_ремонтов);
        }

        // POST: Журнал_выполненных_ремонтов/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ремонта,Дата_начала,Дата_окончания,ID_планового_ремонта,Код_экземпляра,Код_ремонта,Примечания")] Журнал_выполненных_ремонтов журнал_выполненных_ремонтов)
        {
            if (ModelState.IsValid)
            {
                db.Entry(журнал_выполненных_ремонтов).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_планового_ремонта = new SelectList(db.График_плановых_техобслуживаний, "ID_планового_ремонта", "ID_планового_ремонта", журнал_выполненных_ремонтов.ID_планового_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", журнал_выполненных_ремонтов.Код_экземпляра);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Наименование", журнал_выполненных_ремонтов.Код_ремонта);
            return View(журнал_выполненных_ремонтов);
        }

        // GET: Журнал_выполненных_ремонтов/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Журнал_выполненных_ремонтов журнал_выполненных_ремонтов = db.Журнал_выполненных_ремонтов.Find(id);
            if (журнал_выполненных_ремонтов == null)
            {
                return HttpNotFound();
            }
            return View(журнал_выполненных_ремонтов);
        }



        // POST: Журнал_выполненных_ремонтов/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[HandleError(ExceptionType = typeof(System.Data.Entity.Infrastructure.DbUpdateException))]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Журнал_выполненных_ремонтов журнал_выполненных_ремонтов = db.Журнал_выполненных_ремонтов.Find(id);
            db.Журнал_выполненных_ремонтов.Remove(журнал_выполненных_ремонтов);
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
