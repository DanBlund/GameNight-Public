using GameNight.Client.Pages;
using GameNight.Server.Data;
using GameNight.Shared.EntityClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace GameNight.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoggController : ControllerBase
{
    private readonly DataContext _context;
    public LoggController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Logg>> CreateLogg(Logg logg)
    {
        if (logg.Dictator is not null)
        {
            logg.Dictator = await _context.Players.FindAsync(logg.DictatorId);
            logg.DictatorId = logg.DictatorId;
        }
        else
        {
            logg.Dictator = null;
            logg.DictatorId = null;
        }
        logg.DateOfEvent = DateTime.Now;

        _context.Loggs.Add(logg);
        await _context.SaveChangesAsync();
        return Ok(logg);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Logg>>> GetAllLoggs()
    {
        var list = await _context.Loggs.Include(l => l.Dictator).Include(l => l.Subjects).ToListAsync();
        return Ok(list);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Logg>> DeleteLogg(int id)
    {
        var dbLogg = _context.Loggs.Include(l => l.Dictator).Include(l => l.Subjects).FirstOrDefault(l => l.Id == id);
        if (dbLogg == null)
            return NotFound("This Logg does not exist");

        if (dbLogg.Dictator is not null)
        {
            dbLogg.Dictator.TimesDictator -= 1;
            dbLogg.Dictator.TimesAttended -= 1;
            foreach (Subject sub in dbLogg.Subjects)
            {
                Player? player = await _context.Players.FirstOrDefaultAsync(p => p.Id == sub.SubjectId);
                if (player is not null)
                    player.TimesAttended -= 1;
            }
        }

        _context.Loggs.Remove(dbLogg);
        await _context.SaveChangesAsync();

        return Ok();
    }

}
