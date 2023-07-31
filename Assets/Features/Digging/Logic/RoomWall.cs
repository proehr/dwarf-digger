using UnityEngine;

namespace Features.Digging.Logic {

    public class RoomWall : MonoBehaviour{
        //TODO System bauen dass jedem RoomWallDiggableObject den jeweils dazugehörigen Raum beim Bau der Szene zuweist
        //(Maybe nützlich beim generieren von Ebenen)
        public RoomManager roomManager;

        private void OnDestroy()
        {
            roomManager.SpawnEnemiesInRoom();
        }
    }
}
