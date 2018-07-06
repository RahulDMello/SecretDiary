using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SecretDiary.Models;

namespace SecretDiary.Controllers
{
    [Authorize()]
    public class DiaryEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DiaryEntries
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var query = from entry in db.Entries
                        where entry.UserID == userid
                        select entry;
            return View(query.ToList());
        }

        // GET: DiaryEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.Entries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiaryEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryID,EntryDate,Entry")] DiaryEntry diaryEntry)
        {
            if (ModelState.IsValid)
            {
                diaryEntry.UserID = User.Identity.GetUserId();
                db.Entries.Add(diaryEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diaryEntry);
        }

        // GET: DiaryEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.Entries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryID,EntryDate,Entry")] DiaryEntry diaryEntry)
        {
            if (ModelState.IsValid)
            {
                diaryEntry.UserID = User.Identity.GetUserId();
                db.Entry(diaryEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.Entries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaryEntry diaryEntry = db.Entries.Find(id);
            db.Entries.Remove(diaryEntry);
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
