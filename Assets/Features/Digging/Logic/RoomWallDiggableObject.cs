using UnityEngine;

namespace Features.Digging.Logic {

    public class RoomWallDiggableObject : MonoBehaviour{
        //TODO System bauen dass jedem RoomWallDiggableObject den jeweils dazugehörigen Raum beim Bau der Szene zuweist
        //(Maybe nützlich beim generieren von Ebenen)
        [SerializeField] private RoomManager roomManager;

        private void OnDestroy()
        {
            roomManager.OnWallBreak();
        }
    }
}
