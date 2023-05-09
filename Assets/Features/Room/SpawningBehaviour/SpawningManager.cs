namespace Features.Room.SpawningBehaviour {
    using System.Collections.Generic;
    using Combat.Logic;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "SpawningManager", menuName = "Features/SpawningBehaviour/SpawningManager")]
    public class SpawningManager : ScriptableObject {
        [SerializeField] private SpawningManagerData managerData;

        public SpawningManagerData ManagerData => managerData;

        public void OnSpawn(int numToSpawn, List<Vector3> area) {
            List<GameObject> spawnedMonsters = managerData.SpawnedMonsters;
            for (int i = 0; i < numToSpawn; i++) {
                GameObject spawnedEntity = Instantiate(managerData.TestSpawnableEntity, new Vector3(0, 0, 0), Quaternion.identity);
                spawnedMonsters.Add(spawnedEntity);                
            }
            //TODO Spawn logic überdenken (Wer setzt den EnemyCount? SpawningManager oder RoomManager? Und wann?)
            //TODO Instantiate in Area (Maybe für später kann man jeden Gegnertypen Mappen auf einen Strength Wert und dann accordingly der Ebene spawnen
        }
    }
}
