using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using RAD302Week5DataLayer.ppowell.ViewModels;
using WebApplicationGames.Models;

namespace WebApplicationGames.Data
{
    public class GameRepository : IGame<Game>
    {
        ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Game entity)
        {
            _context.Games.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Game> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<Game> Find(Expression<Func<Game, bool>> predicate)
        {
            return _context.Games.Where(predicate);
        }

        public Game Get(int id)
        {
            return _context.Find<Game>(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        public IEnumerable<GameScore> GetScores(Game entity)
        {
            return _context.Games.Where(g => g.GameID.Equals(entity.GameID)).First().scores;
        }

        public IEnumerable<ApplicationUser> GetGamersTagOfGame(string gameName)
        {

            //var scores = _context.GameScores.Where(gs => gs.game.GameName.ToLower().Equals(gameName.ToLower()));
            var scores = _context.GameScores.Where(gs => gs.game.GameName.ToLower().Equals(gameName.ToLower())).Select(s=>s.player);

            return scores;
        }

        public IEnumerable<GameScore> GetTopScores(int Top, Game entity)
        {
            return GetScores(entity).OrderByDescending(s => s.score).Take(Top);
        }

        public void Remove(Game entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Game> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void AddScore(GameScore newScore)
        {
            _context.GameScores.Add(newScore);
            _context.SaveChanges();
        }


    }
}
