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
    public class Работник_в_ремонте1Controller : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Работник_в_ремонте1
        public ActionResult Index()
        {
            var работник_в_ремонте = db.Работник_в_ремонте.Include(р => р.Журнал_выполненных_ремонтов).Include(р => р.Работники).Include(р => р.Роли_работников);
            return View(работник_в_ремонте.ToList());
        }

        // GET: Работник_в_ремонте1/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работник_в_ремонте работник_в_ремонте = db.Работник_в_ремонте.Find(id);
            if (работник_в_ремонте == null)
            {
                return HttpNotFound();
            }
            return View(работник_в_ремонте);
        }

        // GET: Работник_в_ремонте1/Create
        public ActionResult Create()
        {
            ViewBag.ID_ремонта = new SelectList(db.Журнал_выполненных_ремонтов, "ID_ремонта", "ID_ремонта");
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия");
            ViewBag.Код_роли = new SelectList(db.Роли_работников, "Код_роли", "Наименование");
            return View();
        }

        // POST: Работник_в_ремонте1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_работника,ID_ремонта,Код_роли")] Работник_в_ремонте работник_в_ремонте)
        {
            if (ModelState.IsValid)
            {
                работник_в_ремонте.ID_работника = Guid.NewGuid();
                db.Работник_в_ремонте.Add(работник_в_ремонте);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ремонта = new SelectList(db.Журнал_выполненных_ремонтов, "ID_ремонта", "ID_ремонта", работник_в_ремонте.ID_ремонта);
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", работник_в_ремонте.ID_работника);
            ViewBag.Код_роли = new SelectList(db.Роли_работников, "Код_роли", "Наименование", работник_в_ремонте.Код_роли);
            return View(работник_в_ремонте);
        }

        // GET: Работник_в_ремонте1/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работник_в_ремонте работник_в_ремонте = db.Работник_в_ремонте.Find(id);
            if (работник_в_ремонте == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ремонта = new SelectList(db.Журнал_выполненных_ремонтов, "ID_ремонта", "Примечания", работник_в_ремонте.ID_ремонта);
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", работник_в_ремонте.ID_работника);
            ViewBag.Код_роли = new SelectList(db.Роли_работников, "Код_роли", "Наименование", работник_в_ремонте.Код_роли);
            return View(работник_в_ремонте);
        }

        // POST: Работник_в_ремонте1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_работника,ID_ремонта,Код_роли")] Работник_в_ремонте работник_в_ремонте)
        {
            if (ModelState.IsValid)
            {
                db.Entry(работник_в_ремонте).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ремонта = new SelectList(db.Журнал_выполненных_ремонтов, "ID_ремонта", "Примечания", работник_в_ремонте.ID_ремонта);
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", работник_в_ремонте.ID_работника);
            ViewBag.Код_роли = new SelectList(db.Роли_работников, "Код_роли", "Наименование", работник_в_ремонте.Код_роли);
            return View(работник_в_ремонте);
        }

        // GET: Работник_в_ремонте1/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Работник_в_ремонте работник_в_ремонте = db.Работник_в_ремонте.Find(id);
            if (работник_в_ремонте == null)
            {
                return HttpNotFound();
            }
            return View(работник_в_ремонте);
        }

        // POST: Работник_в_ремонте1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Работник_в_ремонте работник_в_ремонте = db.Работник_в_ремонте.Find(id);
            db.Работник_в_ремонте.Remove(работник_в_ремонте);
            db.SaveChanges();
            return RedirectToAction("Index");
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
