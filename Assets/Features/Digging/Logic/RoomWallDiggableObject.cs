namespace Features.Digging.Logic {
    using System;
    using System.Collections;
    using UnityEngine;

    public class RoomWallDiggableObject : DiggableObject {
        //TODO System bauen dass jedem RoomWallDiggableObject den jeweils dazugehörigen Raum beim Bau der Szene zuweist
        //(Maybe nützlich beim generieren von Ebenen)
        [SerializeField] private RoomManager roomManager;
        
        protected override IEnumerator DestroyAfterTime() {
            yield return base.DestroyAfterTime();
            roomManager.OnWallBreak();
        }
    }
}
