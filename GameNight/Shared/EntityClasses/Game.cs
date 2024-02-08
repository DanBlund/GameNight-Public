using GameNight.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Shared.EntityClasses;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int? BestMaxPlayers { get; set; }
    public int? BestMinPlayers { get; set; }
    public string Description { get; set; } = String.Empty;
    public int? GameLength { get; set; }
    public GameComplexity? GameComplexity { get; set; }
    public GameRatings? AvarageRatingOfAttended { get; set; }
    public Player? Location { get; set; } 
    public int? PlayerId { get; set; }
    public bool Retired { get; set; }
    public string ImageUrl { get; set; } = String.Empty;
    public string ThumbnailUrl { get; set; } = String.Empty;

}
