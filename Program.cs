using GameLibrary.Menu;
using GameLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameLibrary.SubtaskOne;

namespace GameLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var twoTask = new GameLibrary.Menu.Menu("TwoTask", new List<IMenuItem>
            {
                new SubtaskOne(),
                new SubtaskTwo(),
                new SubtaskThree(),
                new SubtaskFour(),
                new SubtaskFive(),
            });

            var threeTask = new GameLibrary.Menu.Menu("threeTask", new List<IMenuItem>
            {
                new ThreeTask.SubtaskOne(),
                new ThreeTask.SubtaskTwo(),
                new ThreeTask.SubtaskThree(),
                new ThreeTask.SubtaskFour(),
                new ThreeTask.SubtaskFive(),
                new ThreeTask.SubtaskSix(),
            });

            var FourTask = new GameLibrary.Menu.Menu("FourTask", new List<IMenuItem>
            {
                new FourTask.SubtaskOne(),
                new FourTask.SubtaskTwo(),
                new FourTask.SubtaskThree(),
            });


            var mainMenu = new GameLibrary.Menu.Menu("Главное меню", new List<IMenuItem>
            {
                new TaskOne(),
                twoTask,
                threeTask,
                FourTask
            });

            mainMenu.Execute();
        }
    }
}
