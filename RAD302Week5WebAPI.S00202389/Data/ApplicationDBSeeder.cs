using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using WebApplicationGames.Models;

namespace WebApplicationGames.Data
{
    public class ApplicationDbSeeder
    {
        private readonly ApplicationDbContext _ctx;

        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationDbSeeder(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            
        }
        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            // Seed Game Data
            if (_ctx.Games.Count() < 2)
                {
                    _ctx.Games.AddRange(new Game[] {
                    new Game { GameName = "Battle Call" },
                    new Game { GameName = "Pong" },
                    new Game { GameName = "POP3" }
                });
            }
            _ctx.SaveChanges();

            // Seed the Main User
            Random r = new Random();
            if (_ctx.Users.Count() == 0)
            {
                List<ApplicationUser> UserSeeds = new List<ApplicationUser> {
                            new ApplicationUser
                                {
                                    XP = r.Next(400),
                                    UserName = "powell.paul@itsligo.ie",
                                    Email = "powell.paul@itsligo.ie",
                                    EmailConfirmed = true,
                                    GamerTag = "ppowell",
                                    SecurityStamp = Guid.NewGuid().ToString()
                                },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "bbloggs" + "@itsligo.ie",
                                Email = "bbloggs" + "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "The Blogger" ,
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "BBlake" + "@itsligo.ie",
                                Email = "BBlake" + "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "Blake 7" ,
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "terminator"+ "@itsligo.ie",
                                Email = "terminator"+ "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "The Terminator",
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "Player1"+ "@itsligo.ie",
                                Email = "Player1"+ "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "Player 1" ,
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "Player2"+ "@itsligo.ie",
                                Email = "Player2"+ "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "Player 2" ,
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            new ApplicationUser
                            {
                                XP = r.Next(400),
                                UserName = "Player3"+ "@itsligo.ie",
                                Email = "Player3"+ "@itsligo.ie",
                                EmailConfirmed = true,
                                GamerTag = "Player 3" ,
                                SecurityStamp = Guid.NewGuid().ToString()
                            },
                            };
                // Create all Users with the same password
                foreach (ApplicationUser user in UserSeeds)
                {
                    var result = await _userManager.CreateAsync(user, "Rad302$1");

                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create user in Seeding");
                    }
                }
                _ctx.SaveChanges();
            }
/*
            List<GameScore> scores = new List<GameScore>();
            Game bg = _ctx.Games.FirstOrDefault(battle => battle.GameName == "Battle Call");
            if (bg != null)
            {
                foreach (ApplicationUser player in _ctx.Users)
                {
                    //context.GameScores.AddOrUpdate(score => score.PlayerID,
                    scores.Add(new GameScore
                    {
                        PlayerID = player.Id,
                        score = r.Next(1200),
                        GameID = bg.GameID
                    }
                    );
                }
                _ctx.GameScores.AddRange(
                    scores.ToArray());
                _ctx.SaveChanges();
            }*/
        }
    }
}

