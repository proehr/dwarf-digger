using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Features.Room.Logic {
    public class World : MonoBehaviour {
        [SerializeField] private int size;
        [SerializeField] private GameObject diggableObject;
        [SerializeField] private GameObject roomWall;
        [SerializeField] private GameObject container;
        [SerializeField] private GenerationStrategy genStrategy;
    
        private int[,] worldCoords;
        private List<RectInt> roomList;

        public void Start() {
            worldCoords = new int[size, size];
            roomList = new List<RectInt>();
            RandomlyGenerateRoom(3, 6, 10);
            GenerateWorld();
        }
    
        public void RandomlyGenerateRoom(int numRoom, int min, int max){
            for (int i = 0; i < numRoom; i++){
                GenerateCenter(min, max);
            }
        }

        public void GenerateCenter(int min, int max){
            bool intersects;
            RectInt generatedRoom;
            Random random = new Random();

            do {
                intersects = false;
                int w = random.Next(min, max + 1);
                int h = random.Next(min, max + 1);
                int x = random.Next(0, size - w);
                int y = random.Next(0, size - h);

                generatedRoom = new RectInt(x, y, w, h);

                RectInt clipped = new RectInt(x-2, y-2, w+4, h+4);

                foreach (RectInt room in roomList) {
                    if(clipped.Overlaps(room)){
                        intersects = true;
                        break;
                    }
                }
            } while (intersects);

            roomList.Add(generatedRoom);
            genStrategy.Generate(generatedRoom, ref worldCoords);
        }

        public void GenerateWorld() {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i == 0 && j == 0) continue;
                    Vector3 currentPos = new Vector3(i, 0.5f, j);
                    Instantiate(worldCoords[i, j] == 1 ? roomWall : diggableObject, currentPos, Quaternion.identity, container.transform);
                }
            }
        }
    }
}
