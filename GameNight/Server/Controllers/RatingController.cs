using GameNight.Server.Data;
using GameNight.Shared.EntityClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameNight.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    private readonly DataContext _context;
    public RatingController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Rating>>> GetAllRatings()
    {
        var list = _context.Ratings.Include(r => r.Player).Include(r => r.Game).ToList();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rating>> GetRating(int id)
    {
        var dbRating = await _context.Ratings.Include(r => r.Player).Include(r => r.Game).FirstOrDefaultAsync(r => r.Id == id);
        if (dbRating == null)
            return NotFound("This Rating does not exist");

        return Ok(dbRating);
    }

    [HttpPost]
    public async Task<ActionResult<Rating>> CreateRating(Rating rating)
    {
        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();
        return Ok(rating);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Rating>> UpdateRating(int id, Rating rating)
    {
        Rating? dbRating = await _context.Ratings.FindAsync(id);
        if (dbRating == null)
            return NotFound("This Rating does not exist");
        else
        {
            dbRating.PlayerId = rating.PlayerId;
            dbRating.GameId = rating.GameId;
            dbRating.GameRating = rating.GameRating;
        }


        await _context.SaveChangesAsync();
        return Ok(rating);
    }

}
