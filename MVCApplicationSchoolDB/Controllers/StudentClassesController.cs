using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCApplicationSchoolDB.Data;
using MVCApplicationSchoolDB.Models;

namespace MVCApplicationSchoolDB.Controllers
{
    public class StudentClassesController : Controller
    {
        private RainbowSchoolDBContext db = new RainbowSchoolDBContext();

        // GET: StudentClasses
        public ActionResult Index()
        {
            var studentClass = db.StudentClass.Include(s => s.Subjects);
            return View(studentClass.ToList());
        }

        // GET: StudentClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.StudentClass.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            return View(studentClass);
        }

        // GET: StudentClasses/Create
        public ActionResult Create()
        {
            ViewBag.SubId = new SelectList(db.Subject, "SubId", "SubName");
            return View();
        }

        // POST: StudentClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,CId,SubId")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                db.StudentClass.Add(studentClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubId = new SelectList(db.Subject, "SubId", "SubName", studentClass.SubId);
            return View(studentClass);
        }

        // GET: StudentClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.StudentClass.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubId = new SelectList(db.Subject, "SubId", "SubName", studentClass.SubId);
            return View(studentClass);
        }

        // POST: StudentClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,CId,SubId")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubId = new SelectList(db.Subject, "SubId", "SubName", studentClass.SubId);
            return View(studentClass);
        }

        // GET: StudentClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.StudentClass.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            return View(studentClass);
        }

        // POST: StudentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClass studentClass = db.StudentClass.Find(id);
            db.StudentClass.Remove(studentClass);
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
