using GameNight.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.EntityClasses;

public class Rating
{
    public int Id { get; set; }
    public GameRatings? GameRating { get; set; }
    public Player? Player { get; set; }
    public int? PlayerId { get; set; }
    public Game? Game { get; set; }
    public int? GameId { get; set; }
}
