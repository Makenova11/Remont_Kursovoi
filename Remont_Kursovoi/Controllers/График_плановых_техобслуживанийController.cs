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
    public class График_плановых_техобслуживанийController : Controller
    {
        private Ремонт_оборудованияEntities db = new Ремонт_оборудованияEntities();

        // GET: График_плановых_техобслуживаний
        [Authorize]
        public ActionResult Index(string sortOrder)
        {
            //var график_плановых_техобслуживаний = db.График_плановых_техобслуживаний.Include(г => г.Работники).Include(г => г.Типы_ремонта).Include(г => г.Экземпляры_оборудований);
            //return View(график_плановых_техобслуживаний.ToList());
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Дата начала ремонта" : "";
            ViewBag.DateSortParm = sortOrder == "Фамилия" ? "Наименование" : "Фамилия";
            ViewBag.Ekzemplyar = sortOrder == "Наименование" ? "Наименование" : "Наименование";
            ViewBag.KoDEkzemplyar = sortOrder == "Код экземпляра" ? "Код экземпляра" : "Код экземпляра";
            var Data = from s in db.График_плановых_техобслуживаний
                       select s;

            switch (sortOrder)
            {
                case "Дата начала ремонта":
                    Data = Data.OrderByDescending(s => s.Дата_начала_ремонта);
                    break;
                case "Фамилия":
                    Data = Data.OrderBy(s => s.Работники.Фамилия);
                    break;
                case "Наименование":
                    Data = Data.OrderByDescending(s => s.Экземпляры_оборудований.Наименование);
                    break;
                case "Код экземпляра":
                    Data = Data.OrderByDescending(s => s.Код_экземпляра);
                    break;
                default:
                    Data = Data.OrderBy(s => s.Дата_начала_ремонта);
                    break;
            }
            return View(Data.ToList());
        }

        // GET: График_плановых_техобслуживаний/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            График_плановых_техобслуживаний график_плановых_техобслуживаний = db.График_плановых_техобслуживаний.Find(id);
            if (график_плановых_техобслуживаний == null)
            {
                return HttpNotFound();
            }
            return View(график_плановых_техобслуживаний);
        }

        // GET: График_плановых_техобслуживаний/Create
        public ActionResult Create()
        {
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия");
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Наименование", "Наименование");
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование");
            return View();
        }

        // POST: График_плановых_техобслуживаний/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_планового_ремонта,ID_работника,Дата_начала_ремонта,Код_ремонта,Код_экземпляра")] График_плановых_техобслуживаний график_плановых_техобслуживаний)
        {
            if (ModelState.IsValid)
            {
                график_плановых_техобслуживаний.ID_планового_ремонта = Guid.NewGuid();
                db.График_плановых_техобслуживаний.Add(график_плановых_техобслуживаний);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", график_плановых_техобслуживаний.ID_работника);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Наименование", график_плановых_техобслуживаний.Код_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", график_плановых_техобслуживаний.Код_экземпляра);
            return View(график_плановых_техобслуживаний);
        }

        // GET: График_плановых_техобслуживаний/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            График_плановых_техобслуживаний график_плановых_техобслуживаний = db.График_плановых_техобслуживаний.Find(id);
            if (график_плановых_техобслуживаний == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", график_плановых_техобслуживаний.ID_работника);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Наименование", график_плановых_техобслуживаний.Код_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", график_плановых_техобслуживаний.Код_экземпляра);
            return View(график_плановых_техобслуживаний);
        }

        // POST: График_плановых_техобслуживаний/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_планового_ремонта,ID_работника,Дата_начала_ремонта,Код_ремонта,Код_экземпляра")] График_плановых_техобслуживаний график_плановых_техобслуживаний)
        {
            if (ModelState.IsValid)
            {
                db.Entry(график_плановых_техобслуживаний).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_работника = new SelectList(db.Работники, "ID_работника", "Фамилия", график_плановых_техобслуживаний.ID_работника);
            ViewBag.Код_ремонта = new SelectList(db.Типы_ремонта, "Код_ремонта", "Код_ремонта", график_плановых_техобслуживаний.Код_ремонта);
            ViewBag.Код_экземпляра = new SelectList(db.Экземпляры_оборудований, "Код_экземпляра", "Наименование", график_плановых_техобслуживаний.Код_экземпляра);
            return View(график_плановых_техобслуживаний);
        }

        // GET: График_плановых_техобслуживаний/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            График_плановых_техобслуживаний график_плановых_техобслуживаний = db.График_плановых_техобслуживаний.Find(id);
            if (график_плановых_техобслуживаний == null)
            {
                return HttpNotFound();
            }
            return View(график_плановых_техобслуживаний);
        }

        // POST: График_плановых_техобслуживаний/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            График_плановых_техобслуживаний график_плановых_техобслуживаний = db.График_плановых_техобслуживаний.Find(id);
            db.График_плановых_техобслуживаний.Remove(график_плановых_техобслуживаний);
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
