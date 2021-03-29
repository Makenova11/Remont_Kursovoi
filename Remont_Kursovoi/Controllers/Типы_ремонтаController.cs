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
    public class Типы_ремонтаController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Типы_ремонта
        [Authorize]
        public ActionResult Index()
        {
            var типы_ремонта = db.Типы_ремонта.Include(т => т.Типы_оборудования);
            return View(типы_ремонта.ToList());
        }

        // GET: Типы_ремонта/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Типы_ремонта типы_ремонта = db.Типы_ремонта.Find(id);
            if (типы_ремонта == null)
            {
                return HttpNotFound();
            }
            return View(типы_ремонта);
        }

        // GET: Типы_ремонта/Create
        public ActionResult Create()
        {
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа");
            return View();
        }

        // POST: Типы_ремонта/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_ремонта,Наименование,Периодичность,Длительность,ID_типа_оборудования")] Типы_ремонта типы_ремонта)
        {
            if (ModelState.IsValid)
            {
                db.Типы_ремонта.Add(типы_ремонта);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", типы_ремонта.ID_типа_оборудования);
            return View(типы_ремонта);
        }

        // GET: Типы_ремонта/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Типы_ремонта типы_ремонта = db.Типы_ремонта.Find(id);
            if (типы_ремонта == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", типы_ремонта.ID_типа_оборудования);
            return View(типы_ремонта);
        }

        // POST: Типы_ремонта/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_ремонта,Наименование,Периодичность,Длительность,ID_типа_оборудования")] Типы_ремонта типы_ремонта)
        {
            if (ModelState.IsValid)
            {
                db.Entry(типы_ремонта).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", типы_ремонта.ID_типа_оборудования);
            return View(типы_ремонта);
        }

        // GET: Типы_ремонта/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Типы_ремонта типы_ремонта = db.Типы_ремонта.Find(id);
            if (типы_ремонта == null)
            {
                return HttpNotFound();
            }
            return View(типы_ремонта);
        }

        // POST: Типы_ремонта/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Типы_ремонта типы_ремонта = db.Типы_ремонта.Find(id);
            db.Типы_ремонта.Remove(типы_ремонта);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Exception");
            }
            return View();
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
