﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jirka.Snake.Logic.Enums;
//using System.Random;

namespace Jirka.Snake.Logic

{
    public class Game
    {
        // for future configuration
        public int LevelOfTheGame { get; set; }

        public SizeOfTheGame SizeOfTheGame { get; set; }
        
        public SpeedOfTheGame SpeedOfTheGame { get; set; }
        // for future configuration


        public Direction directoryToMove;
        private Snake snake;
        public List<Point> Points { get; set; } 

        public Game(int LevelOfTheGame, SizeOfTheGame SizeOfTheGame, SpeedOfTheGame SpeedOfTheGame)
        {

            // for future configuration
            this.LevelOfTheGame = LevelOfTheGame;
            this.SizeOfTheGame = SizeOfTheGame;
            this.SpeedOfTheGame = SpeedOfTheGame;
            // // for future configuration


            // full the GameGrid of points
            Points = new List<Point>();
            for(int i = 0; i < ((int)SizeOfTheGame -1); i++)
            {
                for(int j = 0; j < ((int)SizeOfTheGame -1); j++)
                {
                    Point point = new Point(i, j);
                    Points.Add(point);    
                }
            }

            var tempPoint = Points.Find(x => x.X == 10 && x.Y == 10);
            snake = new Snake(tempPoint);
            if (tempPoint == null) throw new ArgumentException("No valid location of the snake");
            tempPoint.Status = PointStatus.Snake;
            CreateFood();
        }

        public void MoveSnake()
        {
            if (directoryToMove == Direction.Null) return;

            Point pointOfHead = snake.GetHead();
            bool wasFood = false;
            
            switch (directoryToMove)
            {
                case Direction.Up:
                    wasFood = snake.Move(Points[Points.FindIndex(x => x.X == pointOfHead.X - 1 && x.Y == pointOfHead.Y )], Direction.Up);
                    break;
                case Direction.Down:
                    wasFood = snake.Move(Points[Points.FindIndex(x => x.X == pointOfHead.X + 1 && x.Y == pointOfHead.Y )], Direction.Down);
                    break;
                case Direction.Left:
                    wasFood = snake.Move(Points[Points.FindIndex(x => x.X == pointOfHead.X  && x.Y == pointOfHead.Y - 1)], Direction.Left);
                    break;
                case Direction.Right:
                    wasFood = snake.Move(Points[Points.FindIndex(x => x.X == pointOfHead.X  && x.Y == pointOfHead.Y + 1)], Direction.Right);
                    break;
            }

            if(wasFood)
            {
                CreateFood();
            }
        }

        public void CreateFood()
        {
            List<Point> tempPoints = Points.FindAll(x => x.Status == PointStatus.Empty);
            Random random = new Random();
            int index  = random.Next(0, tempPoints.Count - 1);
            tempPoints[index].Status = PointStatus.Food;

        }

        public void ChangeActuallDirection(Enums.Direction direction)
        {
            if (snake.IsValisDirection(direction))
                directoryToMove = direction;
        }
        

    }
}
