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
    public class Типы_оборудованияController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Типы_оборудования.ToList());
        }


        // GET: Типы_оборудования/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Типы_оборудования/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_типа_оборудования,Наименование_типа")] Типы_оборудования типы_оборудования)
        {
            if (ModelState.IsValid)
            {
                типы_оборудования.ID_типа_оборудования = Guid.NewGuid();
                db.Типы_оборудования.Add(типы_оборудования);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(типы_оборудования);
        }

        // GET: Типы_оборудования/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Типы_оборудования типы_оборудования = db.Типы_оборудования.Find(id);
            if (типы_оборудования == null)
            {
                return HttpNotFound();
            }
            return View(типы_оборудования);
        }

        // POST: Типы_оборудования/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_типа_оборудования,Наименование_типа")] Типы_оборудования типы_оборудования)
        {
            if (ModelState.IsValid)
            {
                db.Entry(типы_оборудования).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(типы_оборудования);
        }

        // GET: Типы_оборудования/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Типы_оборудования типы_оборудования = db.Типы_оборудования.Find(id);
            if (типы_оборудования == null)
            {
                return HttpNotFound();
            }
            return View(типы_оборудования);
        }


        // POST: Типы_оборудования/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Типы_оборудования типы_оборудования = db.Типы_оборудования.Find(id);
            db.Типы_оборудования.Remove(типы_оборудования);
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
