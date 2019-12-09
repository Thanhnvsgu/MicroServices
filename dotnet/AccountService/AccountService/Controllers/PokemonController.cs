using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountService.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PlayerInfo()
        {
            return View();
        }
        public ActionResult RandomCatch()
        {
            return View();
        }
    }
}