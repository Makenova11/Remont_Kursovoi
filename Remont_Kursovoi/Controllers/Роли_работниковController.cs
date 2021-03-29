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
    public class Роли_работниковController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: Роли_работников
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Роли_работников.ToList());
        }

        // GET: Роли_работников/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Роли_работников роли_работников = db.Роли_работников.Find(id);
            if (роли_работников == null)
            {
                return HttpNotFound();
            }
            return View(роли_работников);
        }

        // GET: Роли_работников/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Роли_работников/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Код_роли,Наименование")] Роли_работников роли_работников)
        {
            if (ModelState.IsValid)
            {
                db.Роли_работников.Add(роли_работников);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(роли_работников);
        }

        // GET: Роли_работников/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Роли_работников роли_работников = db.Роли_работников.Find(id);
            if (роли_работников == null)
            {
                return HttpNotFound();
            }
            return View(роли_работников);
        }

        // POST: Роли_работников/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Код_роли,Наименование")] Роли_работников роли_работников)
        {
            if (ModelState.IsValid)
            {
                db.Entry(роли_работников).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(роли_работников);
        }

        // GET: Роли_работников/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Роли_работников роли_работников = db.Роли_работников.Find(id);
            if (роли_работников == null)
            {
                return HttpNotFound();
            }
            return View(роли_работников);
        }

        // POST: Роли_работников/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Роли_работников роли_работников = db.Роли_работников.Find(id);
            db.Роли_работников.Remove(роли_работников);
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
