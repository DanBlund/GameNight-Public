using GameNight.Server.Data;
using GameNight.Shared.EntityClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GameNight.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;
        public PlayerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Player>>> GetAllPlayers()
        {
            var list = _context.Players.ToList();
            return Ok(list);
            //return BadRequest();
            //return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer( int id)
        {
            var dbPlayer = await _context.Players.FindAsync(id);
            if (dbPlayer == null)
                return NotFound("This Player does not exist");

            return Ok(dbPlayer);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> UpdatePlayer(int id, Player player)
        {
            Player dbPlayer = await _context.Players.FindAsync(id) ?? throw new Exception("Player is Null");
            if (dbPlayer is null)
                return NotFound("This Player does not exist");
            else
            {
                dbPlayer.FirstName = player.FirstName;
                dbPlayer.LastName = player.LastName;
                dbPlayer.NickName = player.NickName;
                dbPlayer.Comment = player.Comment;
                dbPlayer.TimesAttended = player.TimesAttended;
                dbPlayer.TimesDictator = player.TimesDictator;
                dbPlayer.DictatorPrecentage = Math.Round((player.TimesDictator / player.TimesAttended) * 100, 3);
                dbPlayer.Attending = player.Attending;
                dbPlayer.IsDictator = player.IsDictator;
                dbPlayer.Retired = player.Retired;
            }
            await _context.SaveChangesAsync();

            return Ok(dbPlayer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var dbPlayer = await _context.Players.FindAsync(id);
            if (dbPlayer == null)
                return NotFound("This Player does not exist");

            _context.Players.Remove(dbPlayer);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    //TODO Lägg till Dto, Request & Mappers
}
