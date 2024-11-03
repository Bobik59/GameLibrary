using GameLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GameDbContext())
            {
                context.Database.EnsureCreated();

                context.Games.AddRange(
                    new Game { Title = "Game 1", Studio = "Studio 1", Genre = "RPG", ReleaseDate = new DateTime(2022, 1, 1) },
                    new Game { Title = "Game 2", Studio = "Studio 2", Genre = "Action", ReleaseDate = new DateTime(2023, 2, 1) }
                );
                context.SaveChanges();

                foreach (var game in context.Games)
                {
                    Console.WriteLine($"Title: {game.Title}, Studio: {game.Studio}, Genre: {game.Genre}, Release Date: {game.ReleaseDate}");
                }
            }
        }
    }
}
