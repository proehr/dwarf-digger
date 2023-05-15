using Common.Logic.Variables;
using UnityEngine;

namespace Features.Digging.Logic
{
    using System;

    public class DiggingTool : MonoBehaviour
    {
        [SerializeField] private BoolVariable isDigging;

        public void Start() {
            
        }

        private void OnTriggerEnter(Collider other)
        {   
            if (isDigging.Get() && other.CompareTag("Diggable") && enabled)
            {
                Debug.Log("Digging Tool On Trigger Enter");
                isDigging.Set(false);
                DiggableObject diggableObject = other.GetComponent<DiggableObject>();
                diggableObject.OnHit(other.ClosestPointOnBounds(transform.position), transform.rotation);
            }
        }
    }
}