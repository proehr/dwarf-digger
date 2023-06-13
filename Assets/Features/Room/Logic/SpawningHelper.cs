namespace Features.Room.Logic {
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    
    [CreateAssetMenu(fileName = "SpawningHelper", menuName = "Features/Room/Logic/SpawningHelper")]
    public class SpawningHelper : ScriptableObject {
        [SerializeField] private List<SpawnableEnemy> spawnableEnemies;

        public GameObject GetEnemy(string name) {
            return (from currentEnemy in spawnableEnemies where currentEnemy.Name.Equals(name) select currentEnemy.Enemy).FirstOrDefault();
        }

        public AudioClip GetSoundClip(string name) {
            return (from currentEnemy in spawnableEnemies where currentEnemy.Name.Equals(name) select currentEnemy.SoundClip).FirstOrDefault();
        }

        public List<GameObject> GetEnemyList(params string[] names) {
            return (from currentEnemy in spawnableEnemies where names.Contains(currentEnemy.Name) select currentEnemy.Enemy).ToList();
        }

        public List<AudioClip> GetSoundClipList(params string[] names) {
            return (from currentEnemy in spawnableEnemies where names.Contains(currentEnemy.Name) select currentEnemy.SoundClip).ToList();
        }
    }
}
