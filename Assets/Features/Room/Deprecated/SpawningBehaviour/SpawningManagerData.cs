namespace Features.Room.Deprecated.SpawningBehaviour {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "SpawningManagerData", menuName = "Features/SpawningBehaviour/SpawningManagerData")]
    public class SpawningManagerData : ScriptableObject {
        [SerializeField] private List<GameObject> spawnableEntities;
        [SerializeField] private GameObject testSpawnableEntity;
        private List<GameObject> spawnedMonsters = new List<GameObject>();
        
        public List<GameObject> SpawnableEntities => spawnableEntities;
        public GameObject TestSpawnableEntity => testSpawnableEntity;
        public List<GameObject> SpawnedMonsters { get => spawnedMonsters; }
    }
}
