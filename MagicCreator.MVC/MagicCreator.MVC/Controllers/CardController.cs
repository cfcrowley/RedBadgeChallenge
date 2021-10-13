using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicCreator.Models;

namespace MagicCreator.MVC.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        

        // GET : Card
        public ActionResult Index()
        {
            var model = new CardListItem[0];
            return View(model);
        }

        // Get : Card
        public ActionResult Create()
        {
            return View();
        }

        // Post : Song
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }

    }
}