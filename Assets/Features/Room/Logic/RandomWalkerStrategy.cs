namespace Features.Room.Logic {
    using System;
    using UnityEngine;
    using Random = System.Random;

    public class RandomWalkerStrategy : GenerationStrategy {
        public override void Generate(RectInt rectRoom, ref int[,] worldCoords) {
            int maxX = rectRoom.x + rectRoom.width;
            int maxY = rectRoom.y + rectRoom.height;

            Random random = new Random();
            
            int xStart = random.Next(rectRoom.x, maxX + 1);
            int yStart = random.Next(rectRoom.y, maxY + 1);

            int numGens = rectRoom.width * rectRoom.height * 3/4;
            for (int i = 0; i < numGens; i++) {
                bool success = false;
                do {
                    double direction = random.NextDouble();
                    int newX = xStart;
                    int newY = yStart;

                    if (direction <= 0.25) newX -= 1;
                    else if (direction <= 0.5) newY -= 1;
                    else if (direction <= 0.75) newX += 1;
                    else newY += 1;

                    if (newX < maxX && newX >= rectRoom.x && newY < maxY && newY >= rectRoom.y) {
                        xStart = newX;
                        yStart = newY;

                        worldCoords[newX, newY] = 1;

                        success = true;
                    }
                } while (!success);
            }
        }
    }
}
