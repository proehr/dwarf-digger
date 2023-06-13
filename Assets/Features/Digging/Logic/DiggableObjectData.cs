using System;
using UnityEngine;

namespace Features.Digging.Logic
{
    [Serializable]
    public class DiggableObjectData
    {
        public string assignedTag;
        public GameObject hitFx;
        public float destructionTimeInSeconds;
    }
    
}