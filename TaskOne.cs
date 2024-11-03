using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Menu;
using GameLibrary.model;

namespace GameLibrary
{
    internal class TaskOne : IMenuItem
    {
        public string Name => "TaskOne";
        public void Execute()
        {
            using (var context = new GameDbContext())
            {
                context.Database.EnsureCreated();

                context.Games.AddRange(
                    new Game
                    {
                        Title = "Hollow Knight",
                        Studio = "Team Cherry",
                        Genre = "Metroidvania",
                        ReleaseDate = new DateTime(2017, 2, 24),
                        Mode = "Single-player",
                        CopiesSold = 3000000
                    },
                    new Game
                    {
                        Title = "Hitman: Codename 47",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2000, 11, 19),
                        Mode = "Single-player",
                        CopiesSold = 6000000
                    },
                    new Game
                    {
                        Title = "Hitman 2",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2002, 9, 30),
                        Mode = "Single-player",
                        CopiesSold = 5000000
                    },
                    new Game
                    {
                        Title = "Hitman: Absolution",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2012, 11, 20),
                        Mode = "Single-player",
                        CopiesSold = 3000000
                    },
                    new Game
                    {
                        Title = "Hitman",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2016, 3, 11),
                        Mode = "Single-player",
                        CopiesSold = 2000000
                    },
                    new Game
                    {
                        Title = "Hitman 2 (2018)",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2018, 11, 13),
                        Mode = "Single-player",
                        CopiesSold = 4000000
                    },
                    new Game
                    {
                        Title = "Hitman 3",
                        Studio = "IO Interactive",
                        Genre = "Stealth",
                        ReleaseDate = new DateTime(2021, 1, 20),
                        Mode = "Single-player",
                        CopiesSold = 3000000
                    },
                    new Game
                    {
                        Title = "Sekiro: Shadows Die Twice",
                        Studio = "FromSoftware",
                        Genre = "Action-adventure",
                        ReleaseDate = new DateTime(2019, 3, 22),
                        Mode = "Single-player",
                        CopiesSold = 5000000
                    }
                );
                context.SaveChanges();

                foreach (var game in context.Games)
                {
                    Console.WriteLine($"Title: {game.Title}, Studio: {game.Studio}, Genre: {game.Genre}, Release Date: {game.ReleaseDate}, Mode: {game.Mode}, Copies Sold: {game.CopiesSold}");
                }
            }
        }
    }
}
