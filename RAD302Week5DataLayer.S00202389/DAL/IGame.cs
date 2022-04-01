using System.Collections.Generic;
using WebApplicationGames.Models;

namespace WebApplicationGames.Data
{
    public interface IGame<T> : IRepository<T> where T : class
    {

        // Might want to implement specific Game Specific functionality Later
        IEnumerable<ApplicationUser> GetGamersTagOfGame(string gameName);
        void AddScore(GameScore newScore);
        IEnumerable<GameScore> GetScores(Game entity);
        IEnumerable<GameScore> GetTopScores(int Top, Game entity);
    }
}
