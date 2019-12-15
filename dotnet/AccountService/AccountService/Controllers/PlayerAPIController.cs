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
    [RoutePrefix("api/v1/player")]
    public class PlayerAPIController : ApiController
    {
        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetPlayers()
        {
            PlayerDao playerDao = new PlayerDao();
            return Ok(playerDao.players());
        }
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPlayer(string id)
        {
            PlayerDao playerDao = new PlayerDao();
            return Ok(playerDao.player(id));
        }
        [Route("search")]
        [HttpPost]
        public IHttpActionResult SearchPlayers(Player player)
        {
            PlayerDao playerDao = new PlayerDao();
            return Ok(playerDao.searchplayers(player));
        }
        [HttpPost]
        [Route("insert")]
        public IHttpActionResult InsertPlayer(Player player)
        {
            PlayerDao playerDao = new PlayerDao();
            player.id = Guid.NewGuid().ToString();

            Player p = playerDao.findPlayerByUserName(player.username);

            if(p.username != null && p.username != "")
            {
                return Content(HttpStatusCode.Conflict, "Tai khoan da ton tai");
            }
            bool rs = playerDao.insertPlayer(player);
            return Ok(rs?"Insert success":"Insert failure");
        }
        [HttpPost]
        [Route("edit")]
        public IHttpActionResult EditPlayer(Player player)
        {
            PlayerDao playerDao = new PlayerDao();
            Player old_player = playerDao.player(player.id);

            Player p = playerDao.findPlayerByUserName(player.username);

            if (p.id != player.id)
            {
                return Content(HttpStatusCode.Conflict, "Tai khoan da ton tai");
            }

            bool rs = playerDao.updatePlayer(player,old_player);
            return Ok(rs ? "Update success" : "Update failure");
        }
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeletePlayer(String id)
        {
            PlayerDao playerDao = new PlayerDao();
            bool rs = playerDao.deletePlayer(id);
            return Ok(rs ? "Delete success" : "Delete failure");
        }
    }
}
