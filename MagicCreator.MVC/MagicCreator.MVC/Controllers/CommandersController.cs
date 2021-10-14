using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagicCreator.Data;

namespace MagicCreator.MVC.Controllers
{
    public class CommandersController : Controller
    {
       private CommanderServices CreateCommanderSerivces()
        {
            var comService = new CommanderServices();
            return comService;
        }

        // GET: Commanders
        public ActionResult Index()
        {
            return View(db.Commanders.ToList());
        }

        // GET: Commanders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commanders.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            return View(commander);
        }

        // GET: Commanders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commanders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommanderId,Name,CardCount,General,DeckStyle,AvgRating")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                db.Commanders.Add(commander);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commander);
        }

        // GET: Commanders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commanders.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            return View(commander);
        }

        // POST: Commanders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommanderId,Name,CardCount,General,DeckStyle,AvgRating")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commander).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commander);
        }

        // GET: Commanders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commanders.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            return View(commander);
        }

        // POST: Commanders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commander commander = db.Commanders.Find(id);
            db.Commanders.Remove(commander);
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
