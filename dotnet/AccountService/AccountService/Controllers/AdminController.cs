using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountService.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Players()
        {
            return View();
        }
        public ActionResult PlayersDetails()
        {
            return View();
        }
        public ActionResult Pokemons()
        {
            return View();
        }
        public ActionResult PokemonsDetails()
        {
            return View();
        }
        public ActionResult PlayersPokemons()
        {
            return View();
        }
        public ActionResult PlayersPokemonsDetails()
        {
            return View();
        }
        public ActionResult CatchPokemon()
        {
            return View();
        }
        public ActionResult Rank()
        {
            return View();
        }
    }
}