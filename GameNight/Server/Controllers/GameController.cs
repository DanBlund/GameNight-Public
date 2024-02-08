using GameNight.Client.Pages;
using GameNight.Server.Data;
using GameNight.Shared.EntityClasses;
using GameNight.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GameNight.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly DataContext _context;
    public GameController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Game>>> GetAllGames()
    {
        var list = await _context.Games.Include(g => g.Location).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var dbGame = await _context.Games.Include(g => g.Location).FirstOrDefaultAsync(g => g.Id == id);
        if (dbGame == null)
            return NotFound("This Game does not exist");
        return Ok(dbGame);
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return Ok(game);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Game>> UpdateGame(int id, Game game)
    {
        Game? dbGame = await _context.Games.FindAsync(id);
        if (dbGame == null)
            return NotFound("This Player does not exist");
        else
        {
            dbGame.Title = game.Title;
            dbGame.MinPlayers = game.MinPlayers;
            dbGame.MaxPlayers = game.MaxPlayers;
            dbGame.BestMaxPlayers = game.BestMaxPlayers;
            dbGame.BestMinPlayers = game.BestMinPlayers;
            dbGame.Description = game.Description;
            dbGame.GameLength = game.GameLength;
            dbGame.GameComplexity = game.GameComplexity;
            dbGame.ImageUrl = game.ImageUrl;
            dbGame.ThumbnailUrl = game.ThumbnailUrl;
            dbGame.Retired = game.Retired;
            dbGame.Location = _context.Players.FirstOrDefault(x => x.Id == game.PlayerId);
        }

        await _context.SaveChangesAsync();
        return Ok(game);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Game>> DeleteGame(int id)
    {
        var dbGame = await _context.Games.FindAsync(id);
        if (dbGame == null)
            return NotFound("This Player does not exist");

        _context.Games.Remove(dbGame);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
