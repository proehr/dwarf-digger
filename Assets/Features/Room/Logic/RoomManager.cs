using System;
using System.Collections;
using System.Collections.Generic;
using Common.Logic.Variables;
using Features.Combat.Logic;
using Features.Combat.Logic.CombatUnits;
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
    [SerializeField] private PlayerCombatParticipant player;

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
        Enemy enemyToSpawn = spawningHelper.GetEnemy(enemyName);
        if (enemyToSpawn != null) {
            for (int i = 0; i < enemyCount; i++) {
                Vector3 pos = Random.insideUnitSphere * radius;
                Vector3 transformPos = transform.position;
                Vector3 adjustedPos = new Vector3(pos.x + transformPos.x, 0, pos.z + transformPos.z);
                Enemy spawnedEnemy = Instantiate(enemyToSpawn, adjustedPos, Quaternion.identity, transform);
                globalEnemyCount.Add(1);
                
                Debug.Log("Spawned Enemy Pos: " + spawnedEnemy.transform.position);
                Debug.Log("Radius Pos: " + pos);
                
                spawnedEnemy.SetTarget(player);
                spawnedEnemy.deathListeners += OnEnemyDespawn;
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
