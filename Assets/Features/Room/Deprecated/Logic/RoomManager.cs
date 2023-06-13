using System.Collections.Generic;
using System.Linq;
using Features.Combat.Logic;
using UnityEngine;

namespace Features.Room.Deprecated.Logic {
    public class RoomManager : MonoBehaviour {

        [SerializeField] private RoomData roomData;
        public void Awake() {
            //TODO Spawn Enemies in room Boundries (maybe idk)
        }

        //TODO Entscheiden wann Gegner gespawned werden sollen
        public void OnWallBreak() {
            if (roomData.RoomOpened.Get()) return;
        
            roomData.SpawningManager.OnSpawn(roomData.RoomEnemyCount, roomData.RoomDimension); //TODO Zeile maybe in Awake schieben
            roomData.StateManagerEnemyCount.Set(roomData.RoomEnemyCount);
        
            HandleDespawnListeners(roomData.SpawningManager.ManagerData.SpawnedMonsters);
        
            roomData.RoomOpened.Set(true); //I guess der Raum kann potentiell mehr als einen Eingang haben aber der Ablauf soll nur einmal durchgeführt werden
        }

        private void HandleDespawnListeners(List<GameObject> monsters) { 
            Debug.Log("Handle Despawn Listener List length: " + monsters.Count);
            foreach (var monsterCombatParticipant in monsters.Select(currentMonster => currentMonster.GetComponent<AbstractCombatParticipant>()).Where(monsterCombatParticipant => monsterCombatParticipant)) {
                Debug.Log("Participant: " + monsterCombatParticipant.name);
                monsterCombatParticipant.deathListeners += OnMonsterDespawn;
            }
        }

        private void OnMonsterDespawn(AbstractCombatParticipant killer) {
            roomData.StateManagerEnemyCount.Add(-1);
        }
    }
}
