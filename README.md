# Snake Game 🐍- Console Version 👨‍💻.
⬜⬜⬜ *

## What is it? 📚
<p>A game made with <b>C# programming language</b>. 🔧</p> 
<p>In this game you take control of a little snake that want to eat his food. Help him not go out-of-bounds or collide with himself. 🕹</p> 

## Game Controls. 🎮

You can use <b>WASD<b> keys to move the snake.

## How was it made? ⚙
<p>With <b>C# Programming language!</b></p>
<ul>
  <li>
    The canvas is a array of elements with a type stored in the <b>"CanvasType" Enum class</b>.
  </li>
  <li>
    First of all the canvas is filled with the "Empty" type, then it's placed the snake and the first food. 
  </li>
  <li>
    When everything is in his place the game loop starts, there the snake verifies what is in the next tile and take a decision:
    
      if (nextTile == CanvasType.Empty){
      // add the next tile position in the start of the snake size (first array position) and delete the end of the snake size (last array position). 
    } else if (nextTile == CanvasType.Food){
      // add the next tile position in the start of the snake size (first array position).
      } else if (nextTile == CanvasType.Snake){
      // Game Over :(
      }
  </li>
  <li>
    For the movement we look for user imput and take it to a function that reads out what was pressed and change the snake movement direction for the chosen one.
  </li>
  <li>
    It runs in the console using a render class that reads the canvas tiles and project the correct symbol for each element.
  </li>
</ul>

## Archives guide. 📖

[Game](ConsoleSnake_Game.exe) - ConsoleSnake_Game 🕹
<p></p>

[Classes and Visual Studio files](ConsoleSnake) - Console Snake 📦

## Game Prints. 💻

![image](https://github.com/MauroSLopes/Console-SnakeGame/assets/125579601/e4200e8f-8e83-42c4-a04c-574d4a902e08)
<p></p>

![image](https://github.com/MauroSLopes/Console-SnakeGame/assets/125579601/bbb170bf-660a-41d2-ae9b-f4d2b7aff522)
<p></p>

![image](https://github.com/MauroSLopes/Console-SnakeGame/assets/125579601/6915ca14-5622-4a9f-8480-41f5dc146072)

## Repository Status. ☁

COMPLETED! ✅

