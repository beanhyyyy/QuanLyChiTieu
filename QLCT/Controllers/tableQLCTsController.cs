using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCT.Models;

namespace QLCT.Controllers
{
    public class tableQLCTsController : Controller
    {
        private databaseQLCTEntities db = new databaseQLCTEntities();

        // GET: tableQLCTs
        public ActionResult Index()
        {
            return View(db.tableQLCTs.ToList());
        }

        // GET: tableQLCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableQLCT tableQLCT = db.tableQLCTs.Find(id);
            if (tableQLCT == null)
            {
                return HttpNotFound();
            }
            return View(tableQLCT);
        }

        // GET: tableQLCTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tableQLCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,date1,money1,ghichu")] tableQLCT tableQLCT)
        {
            if(tableQLCT.money1 < 0)
            {
                return View("Create");
            }
            if (ModelState.IsValid)
            {
                tableQLCT.date1 = DateTime.Today;
                db.tableQLCTs.Add(tableQLCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableQLCT);
        }

        // GET: tableQLCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableQLCT tableQLCT = db.tableQLCTs.Find(id);
            if (tableQLCT == null)
            {
                return HttpNotFound();
            }
            return View(tableQLCT);
        }

        // POST: tableQLCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,date1,money1,ghichu")] tableQLCT tableQLCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableQLCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableQLCT);
        }

        // GET: tableQLCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableQLCT tableQLCT = db.tableQLCTs.Find(id);
            if (tableQLCT == null)
            {
                return HttpNotFound();
            }
            return View(tableQLCT);
        }

        // POST: tableQLCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableQLCT tableQLCT = db.tableQLCTs.Find(id);
            db.tableQLCTs.Remove(tableQLCT);
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
