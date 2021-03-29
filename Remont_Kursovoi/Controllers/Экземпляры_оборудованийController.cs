using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Remont_Kursovoi;
using Remont_Kursovoi.Models;

namespace Remont_Kursovoi.Controllers
{
    public class Экземпляры_оборудованийController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Экземпляры_оборудований
        [Authorize]
        public ActionResult Index()
        {
            //var экземпляры_оборудований = db.Экземпляры_оборудований.Include(э => э.Состояние_оборудования).Include(э => э.Типы_оборудования);
            ViewBag.IdTypes = db.Типы_оборудования.ToList();
            return View(db.Экземпляры_оборудований.ToList());
        }

        // GET: Экземпляры_оборудований/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экземпляры_оборудований экземпляры_оборудований = db.Экземпляры_оборудований.Find(id);
            if (экземпляры_оборудований == null)
            {
                return HttpNotFound();
            }
            return View(экземпляры_оборудований);
        }

        // GET: Экземпляры_оборудований/Create
        public ActionResult Create()
        {
            ViewBag.Код_состояния_оборудования = new SelectList(db.Состояние_оборудования, "Код_состояния_оборудования", "Наименование");
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа");
            return View();
        }

        // POST: Экземпляры_оборудований/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_экземпляра,Наименование,Код_состояния_оборудования,ID_типа_оборудования")] Экземпляры_оборудований экземпляры_оборудований)
        {
            if (ModelState.IsValid)
            {
                db.Экземпляры_оборудований.Add(экземпляры_оборудований);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Код_состояния_оборудования = new SelectList(db.Состояние_оборудования, "Код_состояния_оборудования", "Наименование", экземпляры_оборудований.Код_состояния_оборудования);
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", экземпляры_оборудований.ID_типа_оборудования);
            return View(экземпляры_оборудований);
        }

        [HttpPost]
        public ActionResult Index(Guid? IdTypes)
        {
            Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();
            ViewBag.IdTypes = db.Типы_оборудования.ToList();

            var m = db.Экземпляры_оборудований;
            var c = m.ToList();

        if (IdTypes != null)
        {
          c = m.Where(a => a.ID_типа_оборудования == IdTypes).ToList();
        }

            return View(c);
        }




        // GET: Экземпляры_оборудований/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экземпляры_оборудований экземпляры_оборудований = db.Экземпляры_оборудований.Find(id);
            if (экземпляры_оборудований == null)
            {
                return HttpNotFound();
            }
            ViewBag.Код_состояния_оборудования = new SelectList(db.Состояние_оборудования, "Код_состояния_оборудования", "Наименование", экземпляры_оборудований.Код_состояния_оборудования);
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", экземпляры_оборудований.ID_типа_оборудования);
            return View(экземпляры_оборудований);
        }

        // POST: Экземпляры_оборудований/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_экземпляра,Наименование,Код_состояния_оборудования,ID_типа_оборудования")] Экземпляры_оборудований экземпляры_оборудований)
        {
            if (ModelState.IsValid)
            {
                db.Entry(экземпляры_оборудований).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Код_состояния_оборудования = new SelectList(db.Состояние_оборудования, "Код_состояния_оборудования", "Наименование", экземпляры_оборудований.Код_состояния_оборудования);
            ViewBag.ID_типа_оборудования = new SelectList(db.Типы_оборудования, "ID_типа_оборудования", "Наименование_типа", экземпляры_оборудований.ID_типа_оборудования);
            return View(экземпляры_оборудований);
        }

        // GET: Экземпляры_оборудований/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Экземпляры_оборудований экземпляры_оборудований = db.Экземпляры_оборудований.Find(id);
            if (экземпляры_оборудований == null)
            {
                return HttpNotFound();
            }
            return View(экземпляры_оборудований);
        }

        // POST: Экземпляры_оборудований/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Экземпляры_оборудований экземпляры_оборудований = db.Экземпляры_оборудований.Find(id);
            db.Экземпляры_оборудований.Remove(экземпляры_оборудований);
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
