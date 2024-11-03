using GameLibrary.Menu;
using GameLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    internal class FourTask
    {
        internal class SubtaskOne : IMenuItem
        {
            public string Name => "Добавление новой игры";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    Console.Write("Введите название новой игры: ");
                    string title = Console.ReadLine();
                    Console.Write("Введите название студии: ");
                    string studio = Console.ReadLine();

                    var existingGame = context.Games
                        .FirstOrDefault(g => g.Title == title && g.Studio == studio);

                    if (existingGame != null)
                    {
                        Console.WriteLine("Игра с таким названием и студией уже существует.");
                        return;
                    }

                    Console.Write("Введите жанр: ");
                    string genre = Console.ReadLine();
                    Console.Write("Введите дату выхода (ГГГГ-ММ-ДД): ");
                    DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите режим (Singleplayer/Multiplayer): ");
                    string mode = Console.ReadLine();
                    Console.Write("Введите количество проданных копий: ");
                    int copiesSold = int.Parse(Console.ReadLine());

                    var newGame = new Game
                    {
                        Title = title,
                        Studio = studio,
                        Genre = genre,
                        ReleaseDate = releaseDate,
                        Mode = mode,
                        CopiesSold = copiesSold
                    };
                    context.Games.Add(newGame);
                    context.SaveChanges();

                }
            }
        }

        internal class SubtaskTwo : IMenuItem
        {
            public string Name => "Изменение данных существующей игры";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var games = context.Games.ToList();
                    if (!games.Any())
                    {
                        Console.WriteLine("Игры для редактирования не найдены.");
                        return;
                    }

                    int selectedIndex = 0;
                    ConsoleKey key;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Выберите игру для редактирования с помощью стрелок вверх/вниз и нажмите Enter для подтверждения:\n");

                        for (int i = 0; i < games.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            var game = games[i];
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Дата выхода: {game.ReleaseDate.ToShortDateString()}, Режим: {game.Mode}, Продано копий: {game.CopiesSold}");

                            Console.ResetColor();
                        }

                        key = Console.ReadKey().Key;

                        // Обработка навигации
                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex - 1 + games.Count) % games.Count;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex + 1) % games.Count;
                        }

                    } while (key != ConsoleKey.Enter);

                    // Редактирование выбранной игры
                    var selectedGame = games[selectedIndex];
                    Console.Clear();
                    Console.WriteLine($"Редактирование игры '{selectedGame.Title}' от студии '{selectedGame.Studio}'");

                    Console.WriteLine("Введите новые данные. Оставьте поле пустым, чтобы не изменять его.");

                    Console.Write("Жанр: ");
                    string genre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(genre))
                        selectedGame.Genre = genre;

                    Console.Write("Дата выхода (ГГГГ-ММ-ДД): ");
                    string releaseDateInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(releaseDateInput))
                        selectedGame.ReleaseDate = DateTime.Parse(releaseDateInput);

                    Console.Write("Режим (Singleplayer/Multiplayer): ");
                    string mode = Console.ReadLine();
                    if (!string.IsNullOrEmpty(mode))
                        selectedGame.Mode = mode;

                    Console.Write("Количество проданных копий: ");
                    string copiesSoldInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(copiesSoldInput))
                        selectedGame.CopiesSold = int.Parse(copiesSoldInput);

                    context.SaveChanges();

                    Console.WriteLine("Данные игры успешно обновлены.");
                }
            }
        }
        internal class SubtaskThree : IMenuItem
        {
            public string Name => "Удаление игры";
            public void Execute()
            {
                using (var context = new GameDbContext())
                {
                    var games = context.Games.ToList();
                    if (!games.Any())
                    {
                        Console.WriteLine("Игры для удаления не найдены.");
                        return;
                    }

                    int selectedIndex = 0;
                    ConsoleKey key;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Выберите игру для удаления с помощью стрелок вверх/вниз и нажмите Enter для подтверждения:\n");

                        for (int i = 0; i < games.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            var game = games[i];
                            Console.WriteLine($"Название: {game.Title}, Студия: {game.Studio}, Жанр: {game.Genre}, Продано копий: {game.CopiesSold}");

                            Console.ResetColor();
                        }

                        key = Console.ReadKey().Key;

                        // Обработка навигации
                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex - 1 + games.Count) % games.Count;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex + 1) % games.Count;
                        }

                    } while (key != ConsoleKey.Enter);

                    // Подтверждение удаления выбранной игры
                    var selectedGame = games[selectedIndex];
                    Console.Write($"\nВы уверены, что хотите удалить игру '{selectedGame.Title}' от студии '{selectedGame.Studio}'? (да/нет): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation.ToLower() == "да")
                    {
                        context.Games.Remove(selectedGame);
                        context.SaveChanges();
                        Console.WriteLine("Игра успешно удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Удаление отменено.");
                    }
                }
            }
        }
    }
}
