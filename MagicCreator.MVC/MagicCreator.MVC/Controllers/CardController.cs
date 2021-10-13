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
        // GET: Card
        public ActionResult Index()
        {
            var model = new CardListItem[0];
            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            return View();
        }
    }
}