namespace Features.Room.SpawningBehaviour {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "SpawningManagerData", menuName = "Features/SpawningBehaviour/SpawningManagerData")]
    public class SpawningManagerData : ScriptableObject {
        [SerializeField] private List<GameObject> spawnableEntities;
        [SerializeField] private GameObject testSpawnableEntity;

        public List<GameObject> SpawnableEntities => spawnableEntities;
        public GameObject TestSpawnableEntity => testSpawnableEntity;
        public List<GameObject> SpawnedMonsters { get; }
    }
}
