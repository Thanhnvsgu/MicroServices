using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AccountService.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Pokemons()
        {
            return View();
        }
        public ActionResult Player()
        {
            return View();
        }
        public ActionResult PlayerPokemons()
        {
            return View();
        }
        public ActionResult Rank()
        {
            return View();
        }
        public ActionResult CatchPokemon()
        {
            return View();
        }
    }
}
