﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    public class GameController
    {
        public GameController(int size) {
            Rand = new Random();
            canvasTypes = new CanvasType[size,size];
            render = new Renderer(size, canvasTypes);
            this.CanvasSize = size;

            CreateEmpty();
            SnakeCharacter = new Snake(CreateSnake());
            CreateFood();

            GameRunning = true;

            render.Render();
        }
    
        public int CanvasSize { get; set; }
        public CanvasType[,] canvasTypes;
        public Random Rand { get; }
        private Snake SnakeCharacter { get; set; }
        private Renderer render;
        public Boolean GameRunning { get; set; }

        private void CreateEmpty()
        {
            for (int i = 0; i < CanvasSize; i++) {
                for (int j = 0; j < CanvasSize; j++)
                {
                    canvasTypes[i, j] = CanvasType.Empty;
                }
            }
        }

        private List<Position> CreateSnake() 
        {
            List<Position> snakePositions = new List<Position>();
            for(int i = 0; i < 3; i++)
            {
                Position position = new Position((CanvasSize - i) - 1, (CanvasSize / 2));
                canvasTypes[position.Altura, position.Largura] = CanvasType.Snake;
                snakePositions.Add(position);
            }
            snakePositions.Reverse();
            return snakePositions;
        }

        private List<Position> IsEmpty()
        {
            List<Position> emptySpaces = new List<Position>();
            for (int i = 0; i < CanvasSize; i++)
            {
                for (int j = 0; j < CanvasSize; j++)
                {
                    if (canvasTypes[i, j] == CanvasType.Empty)
                    {
                        emptySpaces.Add(new Position(i, j));
                    }
                }
            }

            return emptySpaces;
        }

        private Position RandomPosition(List<Position> empty)
        {
            return empty.ElementAt(Rand.Next(0, empty.Count));
        }

        public void CreateFood()
        {
            Position emptyPosition = RandomPosition(IsEmpty());

            canvasTypes[emptyPosition.Altura, emptyPosition.Largura] = CanvasType.Food;
        }

        public Position NextPosition()
        {   
            int nextHeight = SnakeCharacter.Size.First().Altura + SnakeCharacter.currentDirection.Altura;
            int nextWidth = SnakeCharacter.Size.First().Largura + SnakeCharacter.currentDirection.Largura;
            Position nextPosition = new Position(nextHeight, nextWidth);
            return nextPosition;
        }

        public void MoveSnake(char key)
        {
            ChangeDirection(key);

            Position nextPos = NextPosition();

            if (nextPos.Altura >= CanvasSize || nextPos.Altura < 0 || nextPos.Largura >= CanvasSize || nextPos.Largura < 0)
            {
                GameRunning = false;
                return;
            }

            CanvasType nextCanvasType = canvasTypes[nextPos.Altura, nextPos.Largura];

            if (nextPos.Altura == SnakeCharacter.Size.Last().Altura && nextPos.Largura == SnakeCharacter.Size.Last().Largura)
            {
                nextCanvasType = CanvasType.Empty;
            }

            switch (nextCanvasType)
            {
                case CanvasType.Empty:
                    SnakeCharacter.Size.Insert(0, new Position(nextPos.Altura, nextPos.Largura));
                    canvasTypes[SnakeCharacter.Size.Last().Altura, SnakeCharacter.Size.Last().Largura] = CanvasType.Empty;
                    canvasTypes[nextPos.Altura, nextPos.Largura] = CanvasType.Snake;
                    SnakeCharacter.Size.RemoveAt((SnakeCharacter.Size.Count - 1));
                    break;

                case CanvasType.Food:
                    SnakeCharacter.Size.Insert(0, new Position(nextPos.Altura, nextPos.Largura));
                    canvasTypes[nextPos.Altura, nextPos.Largura] = CanvasType.Snake;
                    CreateFood();
                    break;
                case CanvasType.Snake:
                    GameRunning = false;
                    break;
            }

            render.Render();
        }

        public void ChangeDirection(char key)
        {
            Position oldDirection = SnakeCharacter.currentDirection;

            switch (key)
            {
                case 'a':
                    SnakeCharacter.currentDirection = SnakeCharacter.Direction.left;
                    break;
                case 'w':
                    SnakeCharacter.currentDirection = SnakeCharacter.Direction.up;
                    break;
                case 's':
                    SnakeCharacter.currentDirection = SnakeCharacter.Direction.down;
                    break;
                case 'd':
                    SnakeCharacter.currentDirection = SnakeCharacter.Direction.right;
                    break;
            }

            if(oldDirection.OppositeHeigth == SnakeCharacter.currentDirection.Altura && oldDirection.OppositeWidth == SnakeCharacter.currentDirection.Largura)
            {
                SnakeCharacter.currentDirection = oldDirection;
            }
        }
    }
}
