using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController SnakeGame = new GameController(15);

            Thread.Sleep(1000);

            while ( SnakeGame != null )
            {
                while (!Console.KeyAvailable) {
                    Console.Clear();
                    SnakeGame.MoveSnake();
                    Thread.Sleep(900);
                }
                SnakeGame.ChangeDirection(Console.ReadKey().KeyChar);
            }
        }
    }
}
