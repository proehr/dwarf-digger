namespace Features.Room.Logic {
    using System;
    using UnityEngine;

    [Serializable]
    public class SpawnableEnemy {
        public string Name;
        public GameObject Enemy;
        public AudioClip SoundClip;
    }
}
