namespace Features.Room.Logic {
    using System;
    using UnityEngine;

    public class RectangleStrategy : GenerationStrategy{
        public override void Generate(RectInt rectRoom, ref int[,] worldCoords) {
            for (int i = 0; i < rectRoom.width; i++){
                for (int j = 0; j < rectRoom.height; j++){
                    int adjustedX = rectRoom.x + i;
                    int adjustedY = rectRoom.y + j;
                    worldCoords[adjustedX, adjustedY] = 1;
                }
            }
        }
    }
}
