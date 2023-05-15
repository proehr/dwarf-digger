namespace Features.Room.SpawningBehaviour {
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class SpawningManagerData {
        [SerializeField] private List<GameObject> spawnableEntities;
        [SerializeField] private GameObject testSpawnableEntity;
        private List<GameObject> spawnedMonsters = new List<GameObject>();
        
        public List<GameObject> SpawnableEntities => spawnableEntities;
        public GameObject TestSpawnableEntity => testSpawnableEntity;
        public List<GameObject> SpawnedMonsters { get => spawnedMonsters; }
    }
}
