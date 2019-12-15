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
        [HttpGet]
        public IHttpActionResult GetPokemons()
        {
            PokemonDao pokemonDao = new PokemonDao();
            
            return Ok(pokemonDao.pokemons());
        }
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPokemon(string id)
        {
            PokemonDao pokemonDao = new PokemonDao();

            return Ok(pokemonDao.pokemon(id));
        }
        [Route("search")]
        [HttpPost]
        public IHttpActionResult SearchPokemon(Pokemon pokemon)
        {
            PokemonDao pokemonDao = new PokemonDao();

            return Ok(pokemonDao.searchpokemons(pokemon));
        }
        [Route("insert")]
        [HttpPost]
        public IHttpActionResult InsertPokemon(Pokemon pokemon)
        {
            PokemonDao pokemonDao = new PokemonDao();

            pokemon.id = Guid.NewGuid().ToString();

            return Ok(pokemonDao.insertpokemon(pokemon));
        }
        [Route("edit")]
        public IHttpActionResult UpdatePokemon(Pokemon pokemon)
        {
            PokemonDao pokemonDao = new PokemonDao();

            return Ok(pokemonDao.updatepokemon(pokemon));
        }
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeletePokemon(string id)
        {
            PokemonDao pokemonDao = new PokemonDao();

            return Ok(pokemonDao.deletepokemon(id));
        }
    }
}
