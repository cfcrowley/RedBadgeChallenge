using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicCreator.Models;
using MagicCreator.Services;

namespace MagicCreator.MVC.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private CardServices CreateCardService()
        {
            var cardService = new CardServices();
            return cardService;
        }

        // GET : Card
        public ActionResult Index()
        {
            var service = CreateCardService();
            var model = service.GetCards();
            return View(model);
        }

        // Get : Card
        public ActionResult Create()
        {
            return View();
        }

        // Post : Card
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCardService();

            if (service.CreateCard(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCardService();
            var detail = service.GetCardById(id);
            var model =
                new CardEdit
                {
                    CardId = detail.CardId,
                    Name = detail.Name,
                    Type = detail.Type,
                    ManaValue = detail.ManaValue,
                    LegacyId = detail.LegacyId,
                    ModernId = detail.ModernId,
                    CommanderId = detail.CommanderId,
                    StandardId = detail.StandardId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CardId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateCardService();

            if (service.UpdateCard(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCardService();

            service.DeleteCard(id);

            return RedirectToAction("Index");
        }
    }
}