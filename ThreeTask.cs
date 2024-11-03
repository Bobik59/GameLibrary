using GameLibrary.Menu;
using GameLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    internal class ThreeTask
    {
        internal class SubtaskOne : IMenuItem
        {
            public string Name => "Отображение информации обо всех однопользовательских играх";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var singlePlayerGames = context.Games
                        .Where(g => g.Mode == "Single-player")
                        .ToList();

                    if (singlePlayerGames.Any())
                    {
                        Console.WriteLine("Однопользовательские игры:");
                        foreach (var game in singlePlayerGames)
                        {
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Дата выхода: {game.ReleaseDate.ToShortDateString()}, Продано копий: {game.CopiesSold}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Однопользовательские игры не найдены.");
                    }
                }
            }
        }

        internal class SubtaskTwo : IMenuItem
        {
            public string Name => "Отображение информации обо всех многопользовательских играх";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var multiplayerGames = context.Games
                        .Where(g => g.Mode == "Multi-player")
                        .ToList();

                    if (multiplayerGames.Any())
                    {
                        Console.WriteLine("Многопользовательские игры:");
                        foreach (var game in multiplayerGames)
                        {
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Дата выхода: {game.ReleaseDate.ToShortDateString()}, Продано копий: {game.CopiesSold}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Многопользовательские игры не найдены.");
                    }
                }
            }
        }

        internal class SubtaskThree : IMenuItem
        {
            public string Name => "Показать игру с максимальным количеством проданных копий";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var bestSellingGame = context.Games
                        .OrderByDescending(g => g.CopiesSold)
                        .FirstOrDefault();

                    if (bestSellingGame != null)
                    {
                        Console.WriteLine("Игра с максимальным количеством проданных копий:");
                        Console.WriteLine($"Название: {bestSellingGame.Title}, Студия: {bestSellingGame.Studio}, Жанр: {bestSellingGame.Genre}, Дата выхода: {bestSellingGame.ReleaseDate.ToShortDateString()}, Продано копий: {bestSellingGame.CopiesSold}");
                    }
                    else
                    {
                        Console.WriteLine("Игры не найдены.");
                    }
                }
            }
        }

        internal class SubtaskFour : IMenuItem
        {
            public string Name => "Показать игру с минимальным количеством проданных копий";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var leastSellingGame = context.Games
                        .OrderBy(g => g.CopiesSold)
                        .FirstOrDefault();

                    if (leastSellingGame != null)
                    {
                        Console.WriteLine("Игра с минимальным количеством проданных копий:");
                        Console.WriteLine($"Название: {leastSellingGame.Title}, Студия: {leastSellingGame.Studio}, Жанр: {leastSellingGame.Genre}, Дата выхода: {leastSellingGame.ReleaseDate.ToShortDateString()}, Продано копий: {leastSellingGame.CopiesSold}");
                    }
                    else
                    {
                        Console.WriteLine("Игры не найдены.");
                    }
                }
            }
        }

        internal class SubtaskFive : IMenuItem
        {
            public string Name => "Отображение топ-3 самых продаваемых игр";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var topSellingGames = context.Games
                        .OrderByDescending(g => g.CopiesSold)
                        .Take(3)
                        .ToList();

                    if (topSellingGames.Any())
                    {
                        Console.WriteLine("Топ-3 самых продаваемых игр:");
                        foreach (var game in topSellingGames)
                        {
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Дата выхода: {game.ReleaseDate.ToShortDateString()}, Продано копий: {game.CopiesSold}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Игры не найдены.");
                    }
                }
            }
        }

        internal class SubtaskSix : IMenuItem
        {
            public string Name => "Отображение топ-3 самых непродаваемых игр";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var leastSellingGames = context.Games
                        .OrderBy(g => g.CopiesSold)
                        .Take(3)
                        .ToList();

                    if (leastSellingGames.Any())
                    {
                        Console.WriteLine("Топ-3 самых непродаваемых игр:");
                        foreach (var game in leastSellingGames)
                        {
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Дата выхода: {game.ReleaseDate.ToShortDateString()}, Продано копий: {game.CopiesSold}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Игры не найдены.");
                    }
                }
            }
        }
    }
}
