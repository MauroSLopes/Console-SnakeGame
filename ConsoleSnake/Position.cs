using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    public class Position
    {
        public Position(int i, int j)
        {
            this.Altura = i;
            this.Largura = j;
        }

        public int Altura { get; set; }
        public int Largura { get; set; }

        public int OppositeHeigth
        {
            get
            {
                return -this.Altura;
            }
        }

        public int OppositeWidth
        {
            get
            {
                return -this.Largura;
            }
        }
    }
}
