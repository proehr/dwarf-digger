namespace Features.Room.Logic {
    using System;
    using UnityEngine;
    
    public abstract class GenerationStrategy : MonoBehaviour{
        public abstract void Generate(RectInt rectRoom, ref int[,] worldCoords);
    }
}
