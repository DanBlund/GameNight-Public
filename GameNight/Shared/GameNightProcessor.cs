using GameNight.Shared.EntityClasses;
using GameNight.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameNight.Shared;

public class GameNightProcessor
{
    public GameRatings AvarageRating(Game game, List<Rating>? Ratings)
    {
        if (Ratings is not null)
        {
            double totalRating = 0;
            List<Rating> gameRatings = Ratings.Where(g => g.GameId == game.Id).ToList();
            foreach (Rating rate in gameRatings)
            {
                if (rate.GameRating is not null)
                    totalRating += (double)rate.GameRating;
            }
            double avarageRating = (totalRating / gameRatings.Count);
            avarageRating = Math.Round(avarageRating);
            return (GameRatings)avarageRating;         
        }
        else
            throw new Exception("Rating is null");
    }
    public GameRatings AvarageRatingOfAttended(Game game, List<Rating>? Ratings)
    {
        if (Ratings is not null)
        {
            List<Rating> AttendedRatings = Ratings.Where(r => r.Player.Attending == true).ToList() ?? throw new NullReferenceException("Selected Game is Null");
            return AvarageRating(game, AttendedRatings);
        }
        else
            throw new Exception("Rating is null");
    }
    public string RatingAsString(GameRatings? rating)
    {
        switch (rating)
        {
            case GameRatings.IG:
                return "IG";
            case GameRatings.Gm:
                return "G-";
            case GameRatings.G:
                return "G";
            case GameRatings.Gp:
                return "G+";
            case GameRatings.VGm:
                return "VG-";
            case GameRatings.VG:
                return "VG";
            case GameRatings.VGp:
                return "VG+";
            case GameRatings.MVG:
                return "MVG";
            default:
                return "-";
        }
    }

    //TODO Knapp i Games till detta.  Skapa knapp i GamesDetails till denna
    //public async Task<int> GetRandomGame(List<Game> games)
    //{
    //    Random rng = new Random();
    //    int max = 0;

    //    if (games is not null)
    //        max = games.Count();
    //    int randomGame = rng.Next(1, max);
    //    return randomGame;
    //}
    //public async Task<int> GetRandomGame()
    //{
    //    List<Game> games = await ReturnGames();
    //    var x = await GetRandomGame(games);
    //    return x;
    //}
    //public async Task<List<Game>> ReturnGames()
    //{
    //    HttpClient Http = new HttpClient();
    //    var gamesList = await Http.GetFromJsonAsync<List<Game>>("api/game");

    //    return gamesList ?? new List<Game>();
    //}

}

