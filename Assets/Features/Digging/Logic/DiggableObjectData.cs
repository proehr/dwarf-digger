using UnityEngine;

namespace Features.Digging.Logic
{
    [CreateAssetMenu(fileName = "DiggableObjectData", menuName = "Features/Digging/DiggableObjectData")]
    public class DiggableObjectData : ScriptableObject
    {
        [SerializeField] private GameObject hitFx;
        [SerializeField] private float destructionTimeInSeconds;

        public GameObject HitFx => hitFx;

        public float DestructionTimeInSeconds => destructionTimeInSeconds;
    }
}