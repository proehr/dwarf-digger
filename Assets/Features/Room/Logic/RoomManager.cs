using System;
using System.Collections;
using System.Collections.Generic;
using Common.Logic.Variables;
using Features.Combat.Logic;
using Features.Digging.Logic;
using Features.Room.Logic;
using MyBox;
using UnityEngine;
using Random = UnityEngine.Random;


public class RoomManager : MonoBehaviour {
    [SerializeField] private List<RoomWall> selfRoomWalls;
    
    //[SerializeField] private List<string> enemyNames; //Für später
    [SerializeField] private string enemyName;
    [SerializeField] private SpawningHelper spawningHelper;
    [SerializeField] private IntVariable globalEnemyCount;
    [SerializeField] private int enemyCount;

    private int radius;

    public void Start() {
        InitializeRoom();
        radius = 2;
    }

    public void StartRoom(List<RoomWall> roomWalls, int radius) {
        this.selfRoomWalls = roomWalls;
        this.radius = radius;
        InitializeRoom();
    }

    private void InitializeRoom() {
        //this.selfRoomWalls = room.GenerateRoom(transform.position);
        //TODO Soundclip aus SpawningHelper krieger und abspielen in regelmäßigen Intervallen
        foreach (RoomWall currentWall in selfRoomWalls) {
            currentWall.OnWallBreak += SpawnEnemiesInRoom;
        }
    }

    private void SpawnEnemiesInRoom() {
        GameObject enemyToSpawn = spawningHelper.GetEnemy(enemyName);
        if (enemyToSpawn != null && enemyToSpawn.HasComponent<AbstractCombatParticipant>()) {
            for (int i = 0; i < enemyCount; i++) {
                Vector3 pos = Random.insideUnitSphere * radius;
                Vector3 transformPos = transform.position;
                Vector3 adjustedPos = new Vector3(pos.x + transformPos.x, 0, pos.z + transformPos.z);
                GameObject spawnedEnemy = Instantiate(enemyToSpawn, adjustedPos, Quaternion.identity, transform);
                
                Debug.Log("Spawned Enemy Pos: " + spawnedEnemy.transform.position);
                Debug.Log("Radius Pos: " + pos);

                AbstractCombatParticipant combatParticipant = spawnedEnemy.GetComponent<AbstractCombatParticipant>();
                combatParticipant.deathListeners += OnEnemyDespawn;
            }
        }
        Deregister();
    }

    private void Deregister() {
        foreach (RoomWall currentWall in selfRoomWalls) {
            currentWall.OnWallBreak -= SpawnEnemiesInRoom;
        }
    }

    private void OnEnemyDespawn(AbstractCombatParticipant killer) {
        globalEnemyCount.Add(-1);
    }
}
