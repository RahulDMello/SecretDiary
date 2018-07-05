using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SecretDiary.Models;

namespace SecretDiary.Controllers
{
    public class StickyNotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: StickyNotes/Edit/5
        [Route("/StickyNotes/")]
        public ActionResult Edit()
        {
            var userid = User.Identity.GetUserId();

            if (db.Note.FirstOrDefault(x => x.UserID == userid) == null)
            {
                db.Note.Add(new StickyNote { UserID = userid });
                db.SaveChanges();
            }
            StickyNote stickyNote = db.Note.Where(n => n.UserID == userid).FirstOrDefault();
            if (stickyNote == null)
            {
                return HttpNotFound();
            }
            return View(stickyNote);
        }

        // POST: StickyNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/StickyNotes/")]
        public ActionResult Edit([Bind(Include = "EntryID,UserID,Entry")] StickyNote stickyNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stickyNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(stickyNote);
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
