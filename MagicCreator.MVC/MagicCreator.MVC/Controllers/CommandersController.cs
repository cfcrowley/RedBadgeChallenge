using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagicCreator.Data;
using MagicCreator.Models.Commander;
using MagicCreator.Services;

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
            var service = CreateCommanderSerivces();
            var model = service.GetCommanders();
            return View(model);
        }

        // GET: Commanders/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateCommanderSerivces();
            var model = svc.GetCommanderById(id);

            return View(model);
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
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommanderCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCommanderSerivces();

            if (service.CreateCommander(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Commanders/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateCommanderSerivces();
            var detail = service.GetCommanderById(id);
            var model =
                new CommanderEdit
                {
                    CommanderId = detail.CommanderId,
                    Name = detail.Name,
                    CardCount = detail.CardCount,
                    General = detail.General,
                    DeckStyle = detail.DeckStyle
                };
            return View(model);
        }

        // POST: Commanders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommanderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CommanderId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateCommanderSerivces();

            if (service.UpdateCommander(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your deck could not be updated");
            return View(model);
        }

        // GET: Commanders/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCommanderSerivces();
            var model = svc.GetCommanderById(id);

            return View(model);
        }

        // POST: Commanders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateCommanderSerivces();

            service.DeleteCommander(id);

            return RedirectToAction("Index");
        }


    }
}
