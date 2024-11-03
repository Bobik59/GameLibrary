using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Menu;
using GameLibrary.model;


namespace GameLibrary
{
    internal class SubtaskOne : IMenuItem
    {
        public string Name => "SubtaskOne";
        public void Execute()
        {
            using (var context = new GameDbContext())
            {
                Console.Write("Enter the title of the game: ");
                string userInputTitle = Console.ReadLine();

                var gameByTitle = context.Games
                    .FirstOrDefault(g => g.Title == userInputTitle);

                if (gameByTitle != null)
                {
                    Console.WriteLine("Game found:");
                    Console.WriteLine($"Title: {gameByTitle.Title}");
                    Console.WriteLine($"Studio: {gameByTitle.Studio}");
                    Console.WriteLine($"Genre: {gameByTitle.Genre}");
                    Console.WriteLine($"Release Date: {gameByTitle.ReleaseDate.ToShortDateString()}");
                    Console.WriteLine($"Mode: {gameByTitle.Mode}");
                    Console.WriteLine($"Copies Sold: {gameByTitle.CopiesSold}");
                }
                else
                {
                    Console.WriteLine("Game not found.");
                }
            }

        }

        internal class SubtaskTwo : IMenuItem
        {
            public string Name => "Search by Studio Name";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    Console.Write("Enter the studio name: ");
                    string studioName = Console.ReadLine();

                    var gamesByStudio = context.Games
                        .Where(g => g.Studio == studioName)
                        .ToList();

                    if (gamesByStudio.Any())
                    {
                        Console.WriteLine("Games found:");
                        foreach (var game in gamesByStudio)
                        {
                            Console.WriteLine($"Title: {game.Title}, Release Date: {game.ReleaseDate.ToShortDateString()}, Genre: {game.Genre}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No games found for this studio.");
                    }
                }
            }
        }

        internal class SubtaskThree : IMenuItem
        {
            public string Name => "Search by Studio Name and Game Title";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    Console.Write("Enter the studio name: ");
                    string studio = Console.ReadLine();
                    Console.Write("Enter the game title: ");
                    string gameTitle = Console.ReadLine();

                    var gameByStudioAndTitle = context.Games
                        .FirstOrDefault(g => g.Studio == studio && g.Title == gameTitle);

                    if (gameByStudioAndTitle != null)
                    {
                        Console.WriteLine("Game found:");
                        Console.WriteLine($"Title: {gameByStudioAndTitle.Title}");
                        Console.WriteLine($"Studio: {gameByStudioAndTitle.Studio}");
                        Console.WriteLine($"Genre: {gameByStudioAndTitle.Genre}");
                        Console.WriteLine($"Release Date: {gameByStudioAndTitle.ReleaseDate.ToShortDateString()}");
                        Console.WriteLine($"Mode: {gameByStudioAndTitle.Mode}");
                        Console.WriteLine($"Copies Sold: {gameByStudioAndTitle.CopiesSold}");
                    }
                    else
                    {
                        Console.WriteLine("Game not found.");
                    }
                }
            }
        }

        internal class SubtaskFour : IMenuItem
        {
            public string Name => "Search by Genre";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    Console.Write("Enter the genre: ");
                    string genre = Console.ReadLine();

                    var gamesByGenre = context.Games
                        .Where(g => g.Genre == genre)
                        .ToList();

                    if (gamesByGenre.Any())
                    {
                        Console.WriteLine("Games found:");
                        foreach (var game in gamesByGenre)
                        {
                            Console.WriteLine($"Title: {game.Title}, Studio: {game.Studio}, Release Date: {game.ReleaseDate.ToShortDateString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No games found for this genre.");
                    }
                }
            }
        }

        internal class SubtaskFive : IMenuItem
        {
            public string Name => "Search by Release Year";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    Console.Write("Enter the release year: ");
                    if (int.TryParse(Console.ReadLine(), out int releaseYear))
                    {
                        var gamesByYear = context.Games
                            .Where(g => g.ReleaseDate.Year == releaseYear)
                            .ToList();

                        if (gamesByYear.Any())
                        {
                            Console.WriteLine("Games found:");
                            foreach (var game in gamesByYear)
                            {
                                Console.WriteLine($"Title: {game.Title}, Studio: {game.Studio}, Genre: {game.Genre}, Release Date: {game.ReleaseDate.ToShortDateString()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No games found for this release year.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid year entered.");
                    }
                }
            }
        }
    }
}
