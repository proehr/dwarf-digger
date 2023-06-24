using Common.Logic.Variables;
using Features.Combat.Logic;
using Features.Combat.Logic.CombatUnits;
using Features.Room.Logic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    //[SerializeField] private List<string> enemyNames; //Für später
    [SerializeField] private string enemyName;
    [SerializeField] private SpawningHelper spawningHelper;
    [SerializeField] private IntVariable globalEnemyCount;
    [SerializeField] private int enemyCount;
    [SerializeField] private PlayerCombatParticipant player;

    private int radius;
    private bool hasBeenOpened;

    public void Start()
    {
        radius = 2;
    }

    public void SpawnEnemiesInRoom()
    {
        Enemy enemyToSpawn = spawningHelper.GetEnemy(enemyName);
        if (enemyToSpawn != null && !hasBeenOpened)
        {
            for (int i = 0; i < enemyCount; i++)
            {
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

            hasBeenOpened = true;
        }
    }


    private void OnEnemyDespawn(AbstractCombatParticipant killer)
    {
        globalEnemyCount.Add(-1);
    }
}