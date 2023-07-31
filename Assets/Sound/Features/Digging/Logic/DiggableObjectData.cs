using System;
using UnityEngine;

namespace Features.Digging.Logic
{
    [CreateAssetMenu(fileName = "DiggableObjectData", menuName = "Features/Digging/DiggableObjectData")]
    public class DiggableObjectData : ScriptableObject
    {
        public string assignedTag;
        public GameObject hitFx;
        public float destructionTimeInSeconds;
    }
    
}