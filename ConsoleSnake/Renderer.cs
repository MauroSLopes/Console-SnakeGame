using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    public class Renderer
    {
        public Renderer(int canvas, CanvasType[,] types) 
        { 
            CanvasSize = canvas;
            typeCanvas = types;
        }
        private int CanvasSize { get; set; }
        private CanvasType[,] typeCanvas {  get; set; }

        public void Render()
        {
            if(typeCanvas == null)
            {
                return;
            }

            for(int i = 0; i < CanvasSize; i++)
            {
                for(int j = 0; j < CanvasSize; j++)
                {
                    switch (typeCanvas[i,j])
                    {
                        case CanvasType.Empty:
                            Console.Write(" a");
                            break;
                        case CanvasType.Food:
                            Console.Write(" *");
                            break;
                        case CanvasType.Snake:
                            Console.Write(" ■");
                            break;
                    }
                }
                Console.Write("\n");
            }
            
        }

    }
}
