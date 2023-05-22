namespace Features.Digging.Logic {
    using System;
    using System.Collections;
    using UnityEngine;

    public class RoomWall : DiggableObject {
        //TODO System bauen dass jedem RoomWallDiggableObject den jeweils dazugehörigen Raum beim Bau der Szene zuweist
        //(Maybe nützlich beim generieren von Ebenen)
        public Action OnWallBreak;
        
        protected override IEnumerator DestroyAfterTime() {
            yield return base.DestroyAfterTime();
            OnWallBreak?.Invoke();
        }
    }
}
