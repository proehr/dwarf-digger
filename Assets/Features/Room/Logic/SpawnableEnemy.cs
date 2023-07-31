namespace Features.Room.Logic {
    using System;
    using Combat.Logic;
    using Combat.Logic.CombatUnits;
    using UnityEngine;

    [Serializable]
    public class SpawnableEnemy {
        public string Name;
        public Enemy Enemy;
        public AudioClip SoundClip;
    }
}
