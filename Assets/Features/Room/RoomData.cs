namespace Features.Room {
    using System.Collections.Generic;
    using Common.Logic.Variables;
    using SpawningBehaviour;
    using UnityEngine;

    [CreateAssetMenu(fileName = "RoomData", menuName = "Features/Room/RoomData")]
    public class RoomData : ScriptableObject {
        [SerializeField] private SpawningManager spawningManager;
        [SerializeField] private int roomEnemyCount;
        [SerializeField] private IntVariable stateManagerEnemyCount;
        [SerializeField] private List<Vector3> roomDimension; //Das hier vllt bisschen besser lösen?
        [SerializeField] private BoolVariable roomOpened;
        
        public SpawningManager SpawningManager => spawningManager;
        public IntVariable StateManagerEnemyCount => stateManagerEnemyCount;

        public List<Vector3> RoomDimension {
            get => roomDimension;
            set => roomDimension = value;
        }

        public int RoomEnemyCount {
            get => roomEnemyCount;
            set => roomEnemyCount = value;
        }

        public BoolVariable RoomOpened {
            get => roomOpened;
            set => roomOpened.Set(value);
        }
    }
}
