using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    public class Snake
    {
        public Snake(List<Position> snake) 
        {
            Size = snake;
            Direction = new Directions();

            currentDirection = Direction.up;
        }

        public List<Position> Size { get; set; }
        public Directions Direction { get; }
        public Position currentDirection { get; set; }
        
    }
}
