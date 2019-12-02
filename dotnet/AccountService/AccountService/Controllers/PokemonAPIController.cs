using AccountService.Dao;
using AccountService.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountService.Controllers
{
    [RoutePrefix("api/v1/pokemon")]
    public class PokemonAPIController : ApiController
    {
        [Route("all")]
        public IHttpActionResult GetPokemons()
        {
            PokemonDao pokemonDao = new PokemonDao();
            
            return Ok(pokemonDao.pokemons());
        }
    }
}
