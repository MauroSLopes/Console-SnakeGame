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
            Char NextKey = 'w';


            Thread.Sleep(1000);

            while ( SnakeGame.GameRunning == true )
            {
                while (!Console.KeyAvailable && SnakeGame.GameRunning == true) {
                    Console.Clear();
                    SnakeGame.MoveSnake(NextKey);
                    Thread.Sleep(900);
                }
                if (SnakeGame.GameRunning == true) { 
                    NextKey = Console.ReadKey().KeyChar;
                }
            }

            Console.Clear();
            Console.Beep();
            Console.WriteLine("Game Over :(");
            Console.ReadLine();
        }
    }
}
